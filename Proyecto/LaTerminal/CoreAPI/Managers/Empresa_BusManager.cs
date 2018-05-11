using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    // >> ===================================================================================== <<
    // >> {Type}Manager <<
    // >> Es la clase encargada de procesar los datos sobre la logica del negocio
    // >> ===================================================================================== <<
    public class Empresa_BusManager : BaseManager, ICoreManager<Empresa_Bus>
    {
        // >> CRUD Factory
        private TerminalCrudFactory crudTerminal;
        private Empresa_BusCrudFactory crudEmpresa_Bus;
        // >> Constructor
        public Empresa_BusManager()
        {
            crudTerminal = new TerminalCrudFactory();
            crudEmpresa_Bus = new Empresa_BusCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Empresa_Bus Create(Empresa_Bus empresa_Bus)
        {
            try
            {
                var dbUser = crudEmpresa_Bus.Retrieve(empresa_Bus);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(empresa_Bus, new string[] { "Logo" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                empresa_Bus = crudEmpresa_Bus.Create(empresa_Bus);

                return empresa_Bus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Empresa_Bus RetrieveById(Empresa_Bus empresa_Bus)
        {
            try
            {
                empresa_Bus = crudEmpresa_Bus.Retrieve(empresa_Bus);

                return empresa_Bus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Empresa_Bus> RetrieveAll()
        {
            try
            {
                var empresa_Bus = crudEmpresa_Bus.RetrieveAll();

                return empresa_Bus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Empresa_Bus Update(Empresa_Bus empresa_Bus)
        {
            try
            {
                var dbUser = crudEmpresa_Bus.Retrieve(empresa_Bus);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(empresa_Bus, new string[] { });
                missingFields.ForEach(missing =>
                {
                    empresa_Bus[missing] = dbUser[missing];
                });

                return empresa_Bus = crudEmpresa_Bus.Update(empresa_Bus);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Empresa_Bus empresa_Bus)
        {
            try
            {
                var dbUser = crudEmpresa_Bus.Retrieve(empresa_Bus);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudEmpresa_Bus.Delete(empresa_Bus);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public List<Empresa_Bus> RetrieveAllGroupedByTerminal()
        {
            try
            {
                var empresa_Bus = crudEmpresa_Bus.RetrieveAllGroupedByTerminal();

                empresa_Bus.ForEach(empresa =>
                {
                    empresa.Agrupar = empresa.NOMBRE_TERMINAL;
                });

                return empresa_Bus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        


        // >> Asignar a Terminal
        public void AsignarATerminal(Empresa_Bus empresa_Bus)
        {
            try
            {
                var missingFields = CheckMissingFields(empresa_Bus, only: new string[] { "CEDULA_JUR", "ID_TERMINAL" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                var dbTerminal = crudTerminal.Retrieve(new Terminal()
                {
                    CEDULA_JUR = empresa_Bus.ID_TERMINAL
                });
                if (dbTerminal == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(26);
                }

                var dbEmpresa = crudEmpresa_Bus.Retrieve(empresa_Bus);
                if (dbEmpresa == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(27);
                }


                crudEmpresa_Bus.AsignarATerminal(empresa_Bus);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void DeasignarDeTerminal (Empresa_Bus empresa_Bus)
        {
            try
            {
                var missingFields = CheckMissingFields(empresa_Bus, only: new string[] { "CEDULA_JUR", "ID_TERMINAL" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                var dbTerminal = crudTerminal.Retrieve(new Terminal()
                {
                    CEDULA_JUR = empresa_Bus.ID_TERMINAL
                });
                if (dbTerminal == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(26);
                }

                var dbEmpresa = crudEmpresa_Bus.Retrieve(empresa_Bus);
                if (dbEmpresa == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(27);
                }


                crudEmpresa_Bus.DesasignarDeTerminal(empresa_Bus);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}