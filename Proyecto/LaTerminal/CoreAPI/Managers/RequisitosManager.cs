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
    public class RequisitosManager : BaseManager, ICoreManager<Requisitos>
    {

        private BusCrudFactory crudBus;
        private RequisitosCrudFactory crudReq;

        public RequisitosManager()
        {
            crudBus = new BusCrudFactory();
            crudReq = new RequisitosCrudFactory();
        }

        public Requisitos Create(Requisitos tmpRequisitos)
        {
            try
            {
                var dbUser = crudReq.Retrieve(tmpRequisitos);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(tmpRequisitos, new string[] { "ID" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));


                return tmpRequisitos = crudReq.Create(tmpRequisitos);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public void Delete(Requisitos tmpRequisitos)
        {
            try
            {
                var dbUser = crudReq.Retrieve(tmpRequisitos);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudReq.Delete(tmpRequisitos);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Requisitos> RetrieveAll()
        {
            try
            {
                var requisitos = crudReq.RetrieveAll();

                requisitos.ForEach(req =>
                {
                    req.Agrupar = req.NOMBRE.Substring(0, 1);
                });

                return requisitos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Requisitos RetrieveById(Requisitos tmpRequisitos)
        {
            try
            {
                tmpRequisitos = crudReq.Retrieve(tmpRequisitos);

                return tmpRequisitos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Requisitos Update(Requisitos tmpRequisitos)
        {
            try
            {
                var dbUser = crudReq.Retrieve(tmpRequisitos);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // Omit nullable properties
                var missingFields = CheckMissingFields(tmpRequisitos, new string[] { "" });
                missingFields.ForEach(missing =>
                {
                    tmpRequisitos[missing] = dbUser[missing];
                });

                return tmpRequisitos = crudReq.Update(tmpRequisitos);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
