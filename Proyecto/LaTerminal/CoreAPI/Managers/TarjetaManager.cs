using CoreAPI.Integrations;
using CoreAPI.Integrations.Models;
using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    public class TarjetaManager : BaseManager, ICoreManager<Tarjeta>
    {
        private TarjetaCrudFactory crud;
        private UsuarioCrudFactory crudUsuario;
        private TerminalCrudFactory crudTerminal;
        private TipoTarjetaCrudFactory crudTipoTarjeta;


        private ConfigurationManager configurationManager;
        // >> Constructor
        public TarjetaManager()
        {
            crud = new TarjetaCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
            crudTerminal = new TerminalCrudFactory();
            crudTipoTarjeta = new TipoTarjetaCrudFactory();

            configurationManager = new ConfigurationManager();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Tarjeta Create(Tarjeta tmpTarjeta)
        {
            try
            {

                // >> Usuario Existance
                var dbUser = crudUsuario.Retrieve(new Usuario()
                {
                    Identificacion = tmpTarjeta.Id_Usuario
                });

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(6);
                }
                var  missingFields = CheckMissingFields(tmpTarjeta, force: new string[] { });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                // >> Terminal Existance
                var dbTerminal = crudTerminal.Retrieve(new Terminal()
                {
                    CEDULA_JUR = tmpTarjeta.Id_Terminal
                });

                if (dbTerminal == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(6);
                }

                // >> Tipo Tarjeta Existance
                var dbTipoTarjeta = crudTipoTarjeta.Retrieve(new TipoTarjeta()
                {
                    ID = tmpTarjeta.Id_Tipo
                });

                if (dbTipoTarjeta == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(6);
                }
                return tmpTarjeta = crud.Create(tmpTarjeta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Tarjeta RetrieveById(Tarjeta tmpTarjeta)
        {
            try
            {
                tmpTarjeta = crud.Retrieve(tmpTarjeta);

                return tmpTarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Tarjeta> RetrieveAll()
        {
            try
            {
                var tmpTarjeta = crud.RetrieveAll();

                return tmpTarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Tarjeta Update(Tarjeta tmpTarjeta)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpTarjeta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(tmpTarjeta, new string[] { });
                missingFields.ForEach(missing =>
                {
                    tmpTarjeta[missing] = dbUser[missing];
                });

                return tmpTarjeta = crud.Update(tmpTarjeta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Tarjeta tmpTarjeta)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpTarjeta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crud.Delete(tmpTarjeta);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List
        public List<Tarjeta> RetrieveAllByUsuario(Tarjeta tarjeta)
        {
            try
            {
                var tmpTarjeta = crud.RetrieveAllByIdUsuario(tarjeta);

                return tmpTarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Retrieve By User
        public Tarjeta RetrieveByUser(Tarjeta tarjeta)
        {
            try
            {
                //tarjeta = crud.RetrieveByUser(tarjeta);

                return tarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        // >> Recargar tarjeta 
        // >> Recibe el ID del Usuario en tarjeta.usuario
        // >> Recibe el monto a pagar en tarjet.saldo
        public Boolean Recargar(Tarjeta tarjeta) //Este metodo recarga la tarjeta, recibe la tarjeta con el id del usuario
        {

            try
            {
                UsuarioManager uMng = new UsuarioManager();

                if (tarjeta.Id_Usuario == "")
                    throw new BussinessException(1); // No se ha ingresado el id del usuario

                var u = uMng.UsuarioXTarjeta(tarjeta);

                if (u == null)
                    throw new BussinessException(1); // No hay un usuario con ese ID

                var monto = tarjeta.Saldo;

                if (monto == 0)
                    throw new BussinessException(1); // No se ingreso un monto valido


                tarjeta = RetrieveByUser(tarjeta);

                if (tarjeta == null)
                    throw new BussinessException(1); // No hay un hay tarjeta con ese Id de usuario

                tarjeta.Saldo = tarjeta.Saldo + monto;

                Update(tarjeta);

                EmailPerson eUsuario = new EmailPerson(u.PNombre, u.Correo);

                var envelope = new EmailEnvelope();
                envelope.Content.AddText($"Saludos {u.PNombre},");
                envelope.Content.AddText("Su recarga a sido exitosa por un monto de " + monto +
                    " Colones. Su saldo es de " + tarjeta.Saldo + " Colones.\nPara mas nformacion visite :");
                envelope.Content.AddImage("https://i.imgur.com/DqHQ4t0.jpg");
                envelope.Content.AddButton("https://google.com/", "Google");
                envelope.Subject = "Recarga de tarjeta";
                envelope.To = eUsuario;
                EmailManager.GetInstance().SendMail(envelope);

                return true;

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }


        }

        // >> Solicitar Tarjetas para usuario juridico
        // >> Recibe el ID del Usuario en tarjeta.usuario
        // >> Recibe el monto a pagar en tarjet.saldo
        // >> Recibe la cantidad de tarjetas para turista y la de estudiantes
        // >> Recibe en la terminal que se le va asignar la tarjeta 
        public Boolean solicitarTarjetaUsJuridico(Tarjeta tarjeta, int tTuristas, int tEstudintes, Terminal terminal)
        {
            try
            {
                UsuarioManager uMng = new UsuarioManager();

                if (tarjeta.Id_Usuario == "")
                    throw new BussinessException(1); // No se ha ingresado el id del usuario

                var u = uMng.UsuarioXTarjeta(tarjeta);

                if (u == null)
                    throw new BussinessException(1); // No hay un usuario con ese ID

                u.Id_Rol = "JURIDICO"; // ID ROL USUARIO JURIDICO

                if (uMng.UsuarioXRol(u) == null)
                    throw new BussinessException(1); // No es un ususario Juridico
                Double total = 0;

                if (tEstudintes > 0)
                    total = calcTotalEstudiante(tEstudintes);
                if (tTuristas > 0)
                    total = total + calcTotalTurista(tTuristas);

                if (tarjeta.Saldo < total)
                    throw new BussinessException(1); // El monto ingresado es insuficiente

                // >> GET TERMINAL 

                for (var i = 0; i < tEstudintes; i++)
                {
                    Tarjeta t = new Tarjeta();
                    t.Id_Usuario = u.Identificacion;
                    t.Id_Terminal = terminal.CEDULA_JUR;
                    t.Id_Tipo = "ESTUDIANTE";
                    t.Saldo = 0;  // Si se crea con un monto especifico modificar aqui
                    t.Fecha_Emision = DateTime.Now;
                    t.Fecha_Vencimiento = DateTime.Now.AddYears(1); // fecha de vencimiento cierre curs lectivo
                    t.Estado = "Activo"; // O si se crea ya activas las tarjetas
                    Create(t);
                }

                for (var i = 0; i < tTuristas; i++)
                {
                    Tarjeta t = new Tarjeta();
                    t.Id_Usuario = u.Identificacion;
                    t.Id_Terminal = terminal.CEDULA_JUR;
                    t.Id_Tipo = "TURISTA"; // No debe de ser el ID de la tabla Tipo Tarjeta
                    t.Saldo = 0;  // Si se crea con un monto especifico modificar aqui
                    t.Fecha_Emision = DateTime.Now;
                    t.Fecha_Vencimiento = DateTime.Now.AddYears(1); // fecha de vencimiento default o si hay una fecha especifica para turistas?
                    t.Estado = "Activo"; // O si se crea ya activas las tarjetas
                    Create(t);
                }


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }

        }

        public Double calcTotalEstudiante(int cantEstudiantes)
        {
            try
            {
                if (cantEstudiantes == 0)
                    throw new BussinessException(1); // La cantidad de tarjetas ingresadas es insuficiente

                //TipoTarjetaManager tTMng = new TipoTarjetaManager();

                //tTMng.RetrieveByEstuduante();

                //var resul = cantEstudientes * tTMng.Beneficio;

                return 1;

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return 0;
            }
        }

        public Double calcTotalTurista(int cantTurista)
        {
            try
            {
                if (cantTurista == 0)
                    throw new BussinessException(1); // La cantidad de tarjetas ingresadas es insuficiente

                //TipoTarjetaManager tTMng = new TipoTarjetaManager();

                //tTMng.RetrieveByTurista();

                //var resul = cantTurista * tTMng.Beneficio;

                return 1;

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return 0;
            }
        }

        // >> Reponer tarjeta
        // >> Recibe el ID del Usuario en tarjeta.usuario
        // >> Recibe el monto a pagar en tarjet.saldo
        public Boolean Reponer(Tarjeta tarjeta)
        {
            try
            {
                UsuarioManager uMng = new UsuarioManager();
                double costoReposicion = 30;


                if (tarjeta.Id_Usuario == "")
                    throw new BussinessException(1); // No se ha ingresado el id del usuario

                var u = uMng.UsuarioXTarjeta(tarjeta);

                if (u == null)
                    throw new BussinessException(1); // No hay un usuario con ese ID

                var monto = tarjeta.Saldo;

                if (monto == 0)
                    throw new BussinessException(1); // No se ingreso un monto valido

                tarjeta = RetrieveByUser(tarjeta);

                if (tarjeta == null)
                    throw new BussinessException(1); // No hay un hay tarjeta con ese Id de usuario

                if (monto < costoReposicion)
                    throw new BussinessException(1); // El monto ingresado es insuficiente


                tarjeta.Estado = "Activa";

                Update(tarjeta);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }
        // >> Tarjetas por usuario
        // >> Activate
        public Tarjeta Activate(Tarjeta tmpTarjeta)
        {
            try
            {
                // Missing required fields
                var missingFields = CheckMissingFields(tmpTarjeta, only: new string[] { "Id_Usuario", "Codigo" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));


                var dbTarjeta = crud.Retrieve(tmpTarjeta);
                if (dbTarjeta == null)
                {
                    // >> El la tarjeta no existe
                    throw new BussinessException(9);
                }

                if (dbTarjeta.Estado != "INACTIVA")
                    throw new BussinessException(10);


                var dbUser = crudUsuario.Retrieve(new Usuario()
                {
                    Identificacion = tmpTarjeta.Id_Usuario
                });
                if (dbUser == null)
                {
                    // >> El usuario no existe
                    throw new BussinessException(6);
                }


                var dbTarjetaUsuario = crud.RetrieveWithIdUsuario(tmpTarjeta);
                if (dbTarjetaUsuario == null)
                {
                    // >> El usuario no se relacion a la tarjeta
                    throw new BussinessException(8);
                }

                tmpTarjeta.Estado = "ACTIVA";


                // Complete Fields
                missingFields = CheckMissingFields(tmpTarjeta, new string[] { });
                missingFields.ForEach(missing =>
                {
                    tmpTarjeta[missing] = dbTarjeta[missing];
                });

                return tmpTarjeta = crud.Update(tmpTarjeta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
