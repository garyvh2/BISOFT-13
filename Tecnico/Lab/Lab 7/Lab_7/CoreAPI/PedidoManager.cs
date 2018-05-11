using AccesoDatos.CRUD;
using Entidades;
using Entidades.Enums;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class PedidoManager : BaseManager
    {
        private PedidoCrudFactory crudPedido;
        private ProductoCrudFactory crudProductos;
        private TipoProduccionCrudFactory crudTipoProduccion;
        private LineaDetalleCrudFactory crudLineaDetalle;

        public PedidoManager()
        {
            crudPedido = new PedidoCrudFactory();
            crudProductos = new ProductoCrudFactory();
            crudTipoProduccion = new TipoProduccionCrudFactory();
            crudLineaDetalle = new LineaDetalleCrudFactory();
        }

        public List<Pedido> RetrieveAll()
        {
            try
            {
                var pedidos = crudPedido.RetrieveAll<Pedido>();
                pedidos.ForEach(pedido =>
                {
                    pedido.LineasDePedido = crudLineaDetalle.RetrieveAllByPedido<LineaDetalle>(pedido);
                });

                return pedidos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public void Create(Pedido pedido)
        {
            try
            {
                // >> Buscar si el objeto ya existe previamente en la base de datos
                var dbPedido = crudPedido.Retrieve<Pedido>(pedido);
                if (dbPedido != null)
                    throw new BussinessException(3);

                // >> Buscar campos faltantes en el Pedido
                var missingFields = CheckMissingFields(pedido, new string[] { "Id"});
                if (missingFields.Count > 0)
                    throw new BussinessException(19, ": " + String.Join(",", missingFields.ToArray()));

                // >> Asegurarse que el estado sea valido y que inicie como EN_PROCESO
                EstadoPedido estadoPedido = (EstadoPedido)Enum.Parse(typeof(EstadoPedido), pedido.Estado.ToString());
                if (!Enum.IsDefined(typeof(EstadoPedido), estadoPedido) || estadoPedido != EstadoPedido.EN_PROCESO)
                    throw new BussinessException(16);

                // >> Debe haber alguna linea en el pedido, de lo contrario no se puede realizar
                if (pedido.LineasDePedido.Count > 0)
                {
                    // >> Lista completa de productos
                    var productos = crudProductos.RetrieveAll<Producto>();

                    // >> Validar linea de pedido
                    pedido.LineasDePedido.ForEach(linea =>
                    {
                        // >> Validar campos faltantes de linea
                        missingFields = CheckMissingFields(linea, new string[] { "Id", "IdPedido" });
                        if (missingFields.Count > 0)
                            throw new BussinessException(19, ": " + String.Join(",", missingFields.ToArray()));

                        // >> Validar que el tipo de produccion exista
                        TipoProduccion tipoProduccion = new TipoProduccion { Id = linea.IdTipo };
                        tipoProduccion = crudTipoProduccion.Retrieve<TipoProduccion>(tipoProduccion);
                        if (tipoProduccion == null)
                            throw new BussinessException(20, linea.ToString());

                        // >> Asignar el nombre del tipo de produccion
                        linea.Nombre = tipoProduccion.Nombre;

                        // >> Encontrar el producto y comprobar que la cantidad reservada no sea nayor a la cantidad del proyecto en inventario
                        Producto producto = productos.Find(prod => prod.Id == linea.IdTipo);
                        if (linea.Cantidad > producto.Cantidad)
                            throw new BussinessException(21, ": " + linea.Nombre);

                    });

                    // >> Asegurarse que no existan duplicados en los tipos de produccion
                    var anyDuplicate = pedido.LineasDePedido.GroupBy(linea => linea.IdTipo).Any(grupo => grupo.Count() > 1);
                    if (anyDuplicate)
                        throw new BussinessException(22);

                    // >> Crear Lineas de pedido y pedidos
                    pedido.Id = crudPedido.Create<Pedido>(pedido).Id;
                    pedido.LineasDePedido.ForEach(linea =>
                    {
                        linea.IdPedido = pedido.Id;
                        crudLineaDetalle.Create(linea);
                    });
                }
                else
                    throw new BussinessException(13);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Pedido RetrieveById(Pedido Pedido)
        {
            try
            {
                var pedido = crudPedido.Retrieve<Pedido>(Pedido);
                pedido.LineasDePedido = crudLineaDetalle.RetrieveAllByPedido<LineaDetalle>(pedido);

                return pedido;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public void Update(Pedido pedido)
        {
            try
            {
                // >> Buscar si el objeto ya existe previamente en la base de datos del lo contario sera imposible 
                var dbPedido = crudPedido.Retrieve<Pedido>(pedido);
                if (dbPedido == null)
                    throw new BussinessException(12);

                // >> Si el pedido ha sido entregado no se pueden realizar cambios
                if (dbPedido.Estado == EstadoPedido.ENTREGADO)
                    throw new BussinessException(18);

                // >> Asegurarse que el estado sea valido
                EstadoPedido estadoPedido = (EstadoPedido)Enum.Parse(typeof(EstadoPedido), pedido.Estado.ToString());
                if (!Enum.IsDefined(typeof(EstadoPedido), estadoPedido))
                    throw new BussinessException(15);

                // >> Encontrar los campos faltantes y completarlos con el objeto en base de datos
                var missingFields = CheckMissingFields(pedido, new string[] {});
                missingFields.ForEach(missing =>
                {
                    pedido[missing] = dbPedido[missing];
                });

                crudPedido.Update(pedido);
                // >> Se se incluye una linea entones hay cosas que actualizar
                if (pedido.LineasDePedido != null)
                {
                    // >> Lista completa de productos
                    var productos = crudProductos.RetrieveAll<Producto>();

                    // >> Lineas de detalles en DB
                    var dbLineas = crudLineaDetalle.RetrieveAllByPedido<LineaDetalle>(pedido);

                    // >> Validar linea de pedido
                    pedido.LineasDePedido.ForEach(linea =>
                    {
                        // >> Validar que el tipo de produccion exista
                        TipoProduccion tipoProduccion = new TipoProduccion { Id = linea.IdTipo };
                        tipoProduccion = crudTipoProduccion.Retrieve<TipoProduccion>(tipoProduccion);
                        if (tipoProduccion == null)
                            throw new BussinessException(20, linea.ToString());

                        // >> Asignar el nombre del tipo de produccion
                        linea.Nombre = tipoProduccion.Nombre;


                        // >> Acciones especificas 
                        LineaDetalle dbLinea = dbLineas.Find(dblin => dblin.Id == linea.Id);
                        if (dbLinea == null)
                        {
                            // >> La linea es nueva
                            // >> Validar campos faltantes de linea
                            missingFields = CheckMissingFields(linea, new string[] { "Id", "IdPedido" });
                            if (missingFields.Count > 0)
                                throw new BussinessException(19, ": " + String.Join(",", missingFields.ToArray()));

                            // >> Asignar el nombre del tipo de produccion
                            linea.Nombre = tipoProduccion.Nombre;

                            // >> Encontrar el producto y comprobar que la cantidad reservada no sea nayor a la cantidad del proyecto en inventario
                            Producto producto = productos.Find(prod => prod.Id == linea.IdTipo);
                            if (linea.Cantidad > producto.Cantidad)
                                throw new BussinessException(21, ": " + linea.Nombre);

                            // >> Asignar el pedido a la linea
                            linea.IdPedido = pedido.Id;

                            // >> Crear linea
                            crudLineaDetalle.Create(linea);
                        }
                        else
                        {
                            // >> La linea se esta actualizando
                            // >> Verificar campos en la base y actualizar
                            missingFields = CheckMissingFields(linea, new string[] { "Id", "IdPedido" });
                            missingFields.ForEach(missing =>
                            {
                                linea[missing] = dbLinea[missing];
                            });

                            // >> Validar cantidad de producto
                            Producto producto = productos.Find(prod => prod.Id == linea.IdTipo);
                            double diferencia = Math.Abs(dbLinea.Cantidad - linea.Cantidad);
                            if (producto.Cantidad < diferencia)
                                throw new BussinessException(21, ": " + linea.Nombre);

                            // >> Actualizar Linea
                            crudLineaDetalle.Update(linea);
                        }

                    });

                    // >> Asegurarse que no existan duplicados en los tipos de produccion
                    var anyDuplicate = pedido.LineasDePedido.GroupBy(linea => linea.IdTipo).Any(grupo => grupo.Count() > 1);
                    if (anyDuplicate)
                        throw new BussinessException(22);


                    // >> Verificar lineas presentes en la base de datos que ya no estan presentes en la lista actual
                    var lineasEliminadas = dbLineas.Where<LineaDetalle>(linea => !pedido.LineasDePedido.Any(reqLinea => reqLinea.Id == linea.Id)).ToList();
                    lineasEliminadas.ForEach(linea =>
                    {
                        crudLineaDetalle.Delete(linea);
                    });
                }
                else
                {
                    pedido.LineasDePedido = crudLineaDetalle.RetrieveAllByPedido<LineaDetalle>(pedido);
                }
                // >> Si el estado es ENTREGADO entonces se notifica al usuario
                if (pedido.Estado == EstadoPedido.ENTREGADO)
                {
                    var body = "<strong>Un saludo Cordial, " + pedido.Comercio + "</strong>" +
                               "<p>Es un gusto informarle que su pedido ha sido entregado</p>" +
                               "<hr>" +
                               "<h2>Detalles:</h2>" +
                               "<ul>";

                    pedido.LineasDePedido.ForEach(linea =>
                    {
                        body += "<li>" + linea.Id + ". " + linea.Nombre + ". Cantidad: " + linea.Cantidad + ", Total: " + linea.Total + "</li>";
                    });
                    body += "</ul>";
                    body += "<strong>Gracias por su compra, es un placer servirle</strong>";
                    EmailManager.GetInstance().SendMail(pedido.Email, pedido.Comercio,
                                          "[Granja Cenfotec] - Productos Entregados", body, body);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Pedido Pedido)
        {
            try
            {
                var c = crudPedido.Retrieve<Pedido>(Pedido);

                if (c == null)
                {
                    //Pedido doesn't exist
                    throw new BussinessException(14);
                }

                if (c.Estado == EstadoPedido.ENTREGADO)
                {
                    throw new BussinessException(17);
                }

                if (Pedido.LineasDePedido != null && Pedido.LineasDePedido.Count > 0)
                {
                    Pedido.LineasDePedido = crudLineaDetalle.RetrieveAllByPedido<LineaDetalle>(Pedido);
                    Pedido.LineasDePedido.ForEach(linea =>
                    {
                        crudLineaDetalle.Delete(linea);
                    });
                }

                crudPedido.Delete(Pedido);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
