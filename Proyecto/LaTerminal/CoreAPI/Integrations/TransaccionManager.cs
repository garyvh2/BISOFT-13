using CoreAPI.Integrations.Models;
using DataAccess.CRUD;
using DataAccess.CRUD.TransactionComponents;
using Entities.Classes;
using Entities.Entities;
using Entities.Entities.TransactionEntities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations
{
    public class TransaccionManager
    {
        // CRUDs Entities
        private static UsuarioCrudFactory CRUDUsuario;
        private static TarjetaCrudFactory CRUDTarjeta;
        private static SancionCrudFactory CRUDSancion;
        private static TerminalCrudFactory CRUDTerminal;

        // CRUDs Transaccion
        private static FacturaCrudFactory CRUDFactura;
        private static CompradorCrudFactory CRUDComprador;
        private static TransaccionCrudFactory CRUDTransaccion;
        private static Linea_DetalleCrudFactory CRUDLinea_Detalle;

        // TransaccionManager Instance
        private static TransaccionManager Instance;

        // >> Singleton Return Instance
        public static TransaccionManager GetInstance()
        {
            // If the instance is undefined then create it
            if (Instance == null)
            {
                // CRUDs Entities
                CRUDUsuario = new UsuarioCrudFactory();
                CRUDTarjeta = new TarjetaCrudFactory();
                CRUDSancion = new SancionCrudFactory();
                CRUDTerminal = new TerminalCrudFactory();


                // CRUDs Transaccion
                CRUDFactura = new FacturaCrudFactory();
                CRUDComprador = new CompradorCrudFactory();
                CRUDTransaccion = new TransaccionCrudFactory();
                CRUDLinea_Detalle = new Linea_DetalleCrudFactory();

                // >> Email Manager Instantiation
                Instance = new TransaccionManager();
            }
            // Otherwise return the instance
            return Instance;
        }
        
        //==========================================================================//
        //
        //  Entity Payments
        //
        //==========================================================================//
        // >> Comprar una tarjeta
        public bool PagarTarjeta(PaymentObject<Tarjeta> PaymentObject)
        {
            try
            {
                var new_user = false;

                // >> Propietario de la tarjeta
                var Usuario = CRUDUsuario.RetrieveByCorreo(PaymentObject.Comprador);
                if (Usuario == null)
                {
                    new_user = true;
                    Usuario = PaymentObject.Comprador;
                }

                // >> Perparar tarjeta
                var Frecuencia = ConfigurationService.GetItem<int>("TARJETA_VENCIMIENTO");

                var Monto = ConfigurationService.GetItem<float>("TARJETA_MINIMO");
                var IVA = ConfigurationService.GetItem<float>("TARJETA_MINIMO") * (ConfigurationService.GetItem<float>("IVA") / 100);
                var Tarjeta = new Tarjeta()
                {
                    Codigo = Guid.NewGuid().ToString(),
                    Id_Terminal = PaymentObject.Vendedor.Id_Terminal,
                    Id_Usuario = PaymentObject.Comprador.Identificacion,
                    Id_Tipo = PaymentObject.Producto.Id_Tipo,
                    Saldo = Monto + IVA,
                    Estado = "INACTIVA",
                    Fecha_Emision = DateTime.Now,
                    Fecha_Vencimiento = DateTime.Now.Add(new TimeSpan(Frecuencia, 0, 0, 0))
                };

                PaymentObject.Detalle = "Compra de tarjeta (" + Tarjeta.Codigo + ")";

                // >> Verificar tarjetas anteriores
                var DBTarjeta = CRUDTarjeta.RetrieveByUsuarioTerminalTipo(Tarjeta);
                if (DBTarjeta != null)
                {
                    throw new BussinessException(21);
                }

                // >> Procesar pago
                PaymentObject.Payment.Monto = Tarjeta.Saldo;
                var PaymentResult = PaymentManager.GetInstance().Pay(PaymentObject.Payment);
                if (!PaymentResult)
                {
                    throw new BussinessException(20);
                } else
                {
                    // >> Obtener Tarjeta
                    var Terminal = CRUDTerminal.Retrieve(new Terminal()
                    {
                        CEDULA_JUR = Tarjeta.Id_Terminal
                    });

                    // >> Email Preparation
                    var From        = new EmailPerson(Terminal.NOMBRE, Terminal.CORREO);
                    var To          = new EmailPerson("Nuevo Usuario", Usuario.Correo);
                    var Envelope    = new EmailEnvelope()
                    {
                        To = To,
                        From = From
                    };

                    // >> Nueva cuenta Email
                    if (new_user)
                    {
                        var Clave = PasswordManager.GetInstance().GenerateRandom();
                        Usuario.First_Time = true;
                        Usuario.Id_Rol = "PASAJERO";
                        Usuario.Clave = PasswordManager.GetInstance().MD5Hash(Clave);
                        Usuario = CRUDUsuario.CrearPasajero(Usuario);
                        Envelope.Subject = "[La Terminal] - Nueva Cuenta";
                        Envelope.Content.AddText("Gracias por unirte a La Terminal");
                        Envelope.Content.AddText("Su nueva contraseña temporal es:");
                        Envelope.Content.AddText($"<b>{Clave}</b>");
                        Envelope.Content.AddText("Por su seguridad no mantenga esta información al acceso de terceras personas.");
                        EmailManager.GetInstance().SendMail(Envelope);
                    }

                    // >> Crear tarjeta
                    Tarjeta = CRUDTarjeta.Create(Tarjeta);
                    
                    // >> Almacenar registro de transaccion
                    var Transaccion = new Transaccion()
                    {
                        Id_Terminal         = Tarjeta.Id_Terminal,
                        Id_Usuario          = Tarjeta.Id_Usuario,
                        Id_Tarjeta          = Tarjeta.Codigo,
                        Monto               = Tarjeta.Saldo,
                        Fecha               = Tarjeta.Fecha_Emision,
                        Tipo                = "COMPRA_TARJETA"
                    };
                    Transaccion = CRUDTransaccion.Create(Transaccion);
                    
                    // >> Preparar y Almacenar Factura
                    var Factura = new Factura()
                    {
                        Id_Transaccion = Transaccion.Id,
                        Fecha = Transaccion.Fecha,
                        Vendedor = Terminal.NOMBRE,
                        Detalle = PaymentObject.Detalle,
                        Iva = IVA,
                        Subtotal = Monto,
                        Total = Transaccion.Monto
                    };
                    Factura = CRUDFactura.Create(Factura);

                    // >> Preparar Comprador y Producto
                    var Comprador = new Comprador()
                    {
                        Id_Factura = Factura.Id,
                        Correo = PaymentObject.Comprador.Correo
                    };
                    Comprador = CRUDComprador.Create(Comprador);

                    var Linea_Detalle = new Linea_Detalle()
                    {
                        Id_Factura = Factura.Id,
                        Nombre = "Compra de Tarjeta (" + Tarjeta.Codigo + ")",
                        Cantidad = 1,
                        Valor_Unitario = Monto
                    };
                    Linea_Detalle = CRUDLinea_Detalle.Create(Linea_Detalle);


                    // >> Enviar Correo de Tarjeta
                    Envelope.Subject = "[La Terminal] - Compra de Tarjeta";
                    Envelope.Content.Body = "";
                    Envelope.Content.AddText("Gracias por comprar una tarjeta");
                    Envelope.Content.AddText($"Esta tarjeta es únicamente valida en la terminal <b>{Terminal.NOMBRE}</b>");
                    Envelope.Content.AddText("El código de su tarjeta es");
                    Envelope.Content.AddText($"<b>{Tarjeta.Codigo}</b>");
                    Envelope.Content.AddText($"Saldo disponible <b>{Tarjeta.Saldo}</b>");
                    Envelope.Content.AddText("<br><hr>Detalles de compra:");
                    Envelope.Content.AddTable(
                        new List<string>() { "Nombre de producto", "Valor", "Cantidad", "Impuesto" },
                        new List<List<string>>() { new List<string>() { Linea_Detalle.Nombre, Monto.ToString(), Linea_Detalle.Cantidad.ToString(), ConfigurationService.GetItem<float>("IVA") + "%" } });
                    EmailManager.GetInstance().SendMail(Envelope);

                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }
        // >> Recargar una tarjeta
        public bool PagarRecarga(PaymentObject<Tarjeta> PaymentObject)
        {
            try
            {
                var Usuario = CRUDUsuario.RetrieveByCorreo(PaymentObject.Vendedor);
                if (Usuario == null)
                {
                    Usuario = PaymentObject.Vendedor;
                }

                // >> Perparar tarjeta
                var IVA = PaymentObject.Producto.Saldo * (ConfigurationService.GetItem<float>("IVA") / 100);
                var Monto = PaymentObject.Producto.Saldo + IVA;

                var Tarjeta = CRUDTarjeta.Retrieve(PaymentObject.Producto);
                if (Tarjeta == null)
                {
                    throw new BussinessException(22, ": Código (" + Tarjeta.Codigo + ")");
                }


                PaymentObject.Detalle = "Recarga de tarjeta (" + Tarjeta.Codigo + ")";
                
                // >> Procesar pago
                PaymentObject.Payment.Monto = Monto;
                var PaymentResult = PaymentManager.GetInstance().Pay(PaymentObject.Payment);
                if (!PaymentResult)
                {
                    throw new BussinessException(20);
                }
                else
                {
                    // >> Obtener Terminal
                    var Terminal = CRUDTerminal.Retrieve(new Terminal()
                    {
                        CEDULA_JUR = Tarjeta.Id_Terminal
                    });

                    // >> Email Preparation
                    var From = new EmailPerson(Terminal.NOMBRE, Terminal.CORREO);
                    var To = new EmailPerson(Usuario.Nombre_Completo, Usuario.Correo);
                    var Envelope = new EmailEnvelope()
                    {
                        To = To,
                        From = From
                    };

                    Tarjeta.Saldo += Monto;
                    Tarjeta = CRUDTarjeta.ActualizarSaldo(Tarjeta);

                    // >> Almacenar registro de transaccion
                    var Transaccion = new Transaccion()
                    {
                        Id_Terminal = Tarjeta.Id_Terminal,
                        Id_Usuario = Tarjeta.Id_Usuario,
                        Id_Tarjeta = Tarjeta.Codigo,
                        Monto = Monto,
                        Fecha = Tarjeta.Fecha_Emision,
                        Tipo = "RECARGA_TARJETA"
                    };
                    Transaccion = CRUDTransaccion.Create(Transaccion);

                    // >> Preparar y Almacenar Factura
                    var Factura = new Factura()
                    {
                        Id_Transaccion = Transaccion.Id,
                        Fecha = Transaccion.Fecha,
                        Vendedor = Terminal.NOMBRE,
                        Detalle = PaymentObject.Detalle,
                        Iva = IVA,
                        Subtotal = PaymentObject.Producto.Saldo,
                        Total = Monto
                    };
                    Factura = CRUDFactura.Create(Factura);

                    // >> Preparar Comprador y Producto
                    var Comprador = new Comprador()
                    {
                        Id_Factura = Factura.Id,
                        Nombre_Completo = Usuario.Nombre_Completo ?? "",
                        Telefono = Usuario.Telefono ?? "",
                        Correo = Usuario.Correo ?? ""
                    };
                    Comprador = CRUDComprador.Create(Comprador);

                    var Linea_Detalle = new Linea_Detalle()
                    {
                        Id_Factura = Factura.Id,
                        Nombre = "Recarga de Tarjeta (" + Tarjeta.Codigo + ")",
                        Cantidad = 1,
                        Valor_Unitario = Monto
                    };
                    Linea_Detalle = CRUDLinea_Detalle.Create(Linea_Detalle);


                    // >> Enviar Correo de Tarjeta
                    Envelope.Subject = "[La Terminal] - Recarga de Tarjeta";
                    Envelope.Content.Body = "";
                    Envelope.Content.AddText("Gracias por recargar una tarjeta");
                    Envelope.Content.AddText($"El saldo de la tarjeta es únicamente valido en la terminal <b>{Terminal.NOMBRE}</b>");
                    Envelope.Content.AddText($"Saldo disponible <b>{Tarjeta.Saldo}</b>");
                    Envelope.Content.AddText("<br><hr>Detalles de compra:");
                    Envelope.Content.AddTable(
                        new List<string>() { "Nombre de producto", "Valor", "Cantidad", "Impuesto" },
                        new List<List<string>>() { new List<string>() { Linea_Detalle.Nombre, Monto.ToString(), Linea_Detalle.Cantidad.ToString(), ConfigurationService.GetItem<float>("IVA") + "%" } });
                    EmailManager.GetInstance().SendMail(Envelope);

                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }


        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<\
        // >> List
        public List<Transaccion> RetrieveAll()
        {
            try
            {
                var transacciones = CRUDTransaccion.RetrieveAll();

                return transacciones;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public List<Transaccion> RetrieveAllByUsuario(Usuario usuario)
        {
            try
            {
                var transacciones = CRUDTransaccion.RetrieveAllByIdUsuario(usuario);

                transacciones.ForEach(transaccion =>
                {
                    transaccion.Agrupar = transaccion.Tipo_Name;
                });

                return transacciones;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
