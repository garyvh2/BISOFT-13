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
    public class BusManager : BaseManager, ICoreManager<Bus>
    {
        private UsuarioCrudFactory crudUsuario;
        private BusCrudFactory crudBus;
        private Empresa_BusCrudFactory crudEmpresa;

        public BusManager()
        {
            crudEmpresa = new Empresa_BusCrudFactory();
            crudBus = new BusCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
        }

        public Bus Create(Bus tmpBus)
        {
            try
            {
                var dbUser = crudBus.Retrieve(tmpBus);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(tmpBus, new string[] { "ID_CHOFER", "ESTADO" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));


                return tmpBus = crudBus.Create(tmpBus);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public void Delete(Bus tmpBus)
        {

            try
            {
                var dbUser = crudBus.Retrieve(tmpBus);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudBus.Delete(tmpBus);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Bus> RetrieveAll()
        {
            try
            {
                var bus = crudBus.RetrieveAll();

                bus.ForEach(autobus =>
                {
                    autobus.Agrupar = autobus.NUMERO_PLACA.Substring(0, 1);
                });

                return bus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Bus RetrieveById(Bus tmpBus)
        {
            try
            {
                tmpBus = crudBus.Retrieve(tmpBus);

                return tmpBus;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Bus Update(Bus tmpBus)
        {
            try
            {
                var dbUser = crudBus.Retrieve(tmpBus);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // Omit nullable properties
                var missingFields = CheckMissingFields(tmpBus, new string[] { "Id_Empresa_Bus" });
                missingFields.ForEach(missing =>
                {
                    tmpBus[missing] = dbUser[missing];
                });

                return tmpBus = crudBus.Update(tmpBus);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
