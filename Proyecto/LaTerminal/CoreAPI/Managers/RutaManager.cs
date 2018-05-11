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
    public class RutaManager : BaseManager, ICoreManager<Ruta>
    {
        // >> CRUD Factory
        private RutaCrudFactory crudRuta;
        // >> Constructor
        public RutaManager()
        {
            crudRuta = new RutaCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Ruta Create(Ruta Ruta)
        {
            try
            {
                var dbUser = crudRuta.Retrieve(Ruta);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(Ruta, new string[] { "porLetra" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                Ruta = crudRuta.Create(Ruta);

                return Ruta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Ruta RetrieveById(Ruta Ruta)
        {
            try
            {
                Ruta = crudRuta.Retrieve(Ruta);

                return Ruta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Ruta> RetrieveAll()
        {
            try
            {
                var Ruta = crudRuta.RetrieveAll();

                return Ruta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Ruta Update(Ruta Ruta)
        {
            try
            {
                var dbUser = crudRuta.Retrieve(Ruta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(Ruta, new string[] { });
                missingFields.ForEach(missing =>
                {
                    Ruta[missing] = dbUser[missing];
                });

                return Ruta = crudRuta.Update(Ruta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Ruta Ruta)
        {
            try
            {
                var dbUser = crudRuta.Retrieve(Ruta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudRuta.Delete(Ruta);

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
