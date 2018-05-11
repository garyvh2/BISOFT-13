using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.MAPPER;
using Entities.Classes;
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
    public class EstacionamientoManager : BaseManager, ICoreManager<Estacionamiento>
    {
        // >> CRUD Factory
        private EstacionamientoCrudFactory crudEstacionamiento;
        // >> Constructor
        public EstacionamientoManager()
        {
            crudEstacionamiento = new EstacionamientoCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Estacionamiento Create(Estacionamiento estacionamiento)
        {
            try
            {
                var missingFields = CheckMissingFields(estacionamiento, new string[] { "Id", "Estado" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                estacionamiento = crudEstacionamiento.Create(estacionamiento);

                return estacionamiento;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Estacionamiento RetrieveById(Estacionamiento estacionamiento)
        {
            try
            {
                estacionamiento = crudEstacionamiento.Retrieve(estacionamiento);

                return estacionamiento;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Estacionamiento> RetrieveAll()
        {
            try
            {
                var estacionamiento = crudEstacionamiento.RetrieveAll();

                return estacionamiento;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Estacionamiento Update(Estacionamiento estacionamiento)
        {
            try
            {
                var dbUser = crudEstacionamiento.Retrieve(estacionamiento);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(estacionamiento, new string[] { });
                missingFields.ForEach(missing =>
                {
                    estacionamiento[missing] = dbUser[missing];
                });

                return estacionamiento = crudEstacionamiento.Update(estacionamiento);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Estacionamiento estacionamiento)
        {
            try
            {
                var dbUser = crudEstacionamiento.Retrieve(estacionamiento);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudEstacionamiento.Delete(estacionamiento);

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


    }
}
