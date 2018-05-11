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
    public class QuejaManager : BaseManager, ICoreManager<Queja>
    {

        private QuejaCrudFactory crudQuejas;

        public QuejaManager()
        {
            crudQuejas = new QuejaCrudFactory();
        }

        public Queja Create(Queja quejas)
        {
        
            try
            {
                var dbQuejas = crudQuejas.Retrieve(quejas);

                if (dbQuejas != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(quejas, new string[] { "ID" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return quejas = crudQuejas.Create(quejas);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Queja RetrieveById(Queja quejas)
        {
            try
            {
                quejas = crudQuejas.Retrieve(quejas);

                return quejas;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public List<Queja> RetrieveAll()
        {
            try
            {
                var quejas = crudQuejas.RetrieveAll();

                return quejas;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Queja Update(Queja quejas)
        {
            try
            {
                var dbQuejas = crudQuejas.Retrieve(quejas);

                if (dbQuejas == null)
                {
                    // >> Object is already update on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(quejas, new string[] { });
                missingFields.ForEach(missing =>
                {
                    quejas[missing] = dbQuejas[missing];
                });

                return quejas = crudQuejas.Update(quejas);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public void Delete(Queja quejas)
        {
            try
            {
                var dbQuejas = crudQuejas.Retrieve(quejas);

                if (dbQuejas == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudQuejas.Delete(quejas);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
