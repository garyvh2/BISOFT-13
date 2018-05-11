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
    public class SancionManager : BaseManager, ICoreManager<Sancion>
    {
        private SancionCrudFactory crud;
        // >> Constructor
        public SancionManager()
        {
            crud = new SancionCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Sancion Create(Sancion tmpSancion)
        {
            try
            {
                var missingFields = CheckMissingFields(tmpSancion, new string[] { "Id" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                tmpSancion.Fecha = DateTime.Now;
                return tmpSancion = crud.Create(tmpSancion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Sancion RetrieveById(Sancion tmpSancion)
        {
            try
            {
                tmpSancion = crud.Retrieve(tmpSancion);

                return tmpSancion;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Sancion> RetrieveAll()
        {
            try
            {
                var tmpSancion = crud.RetrieveAll();

                return tmpSancion;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Sancion Update(Sancion tmpSancion)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpSancion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(tmpSancion, new string[] { });
                missingFields.ForEach(missing =>
                {
                    tmpSancion[missing] = dbUser[missing];
                });

                return tmpSancion = crud.Update(tmpSancion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Sancion tmpSancion)
        {
            try
            {
                var dbUser = crud.Retrieve(tmpSancion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crud.Delete(tmpSancion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
