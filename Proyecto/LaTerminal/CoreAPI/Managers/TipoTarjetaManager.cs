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
    public class TipoTarjetaManager : BaseManager, ICoreManager<TipoTarjeta>
    {
        private TipoTarjetaCrudFactory crud;
        // >> Constructor
        public TipoTarjetaManager()
        {
            crud = new TipoTarjetaCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public TipoTarjeta Create(TipoTarjeta tmpTipoTarjeta)
        {
            try
            {
                var missingFields = CheckMissingFields(tmpTipoTarjeta, new string[] { "ID" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                if (tmpTipoTarjeta.BENEFICIO < 1 || tmpTipoTarjeta.BENEFICIO > 100)
                    throw new BussinessException(7);
            
                return crud.Create(tmpTipoTarjeta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public TipoTarjeta RetrieveById(TipoTarjeta tmpTipoTarjeta)
        {
            try
            {
                tmpTipoTarjeta = crud.Retrieve(tmpTipoTarjeta);

                return tmpTipoTarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<TipoTarjeta> RetrieveAll()
        {
            try
            {
                var tmpTipoTarjeta = crud.RetrieveAll();

                return tmpTipoTarjeta;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public TipoTarjeta Update(TipoTarjeta tmpTipoTarjeta)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpTipoTarjeta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(tmpTipoTarjeta, new string[] { });
                missingFields.ForEach(missing =>
                {
                    tmpTipoTarjeta[missing] = dbUser[missing];
                });

                return tmpTipoTarjeta = crud.Update(tmpTipoTarjeta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(TipoTarjeta tmpTipoTarjeta)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpTipoTarjeta);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crud.Delete(tmpTipoTarjeta);

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
