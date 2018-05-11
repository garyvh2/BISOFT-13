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
    public class RequisitoBusManager : BaseManager, ICoreManager<RequisitoBus>
    {

        private BusCrudFactory crudBus;
        private RequisitosCrudFactory crudReq;
        private RequisitoBusCrudFactory crudReqBus;

        public RequisitoBusManager()
        {
            crudBus = new BusCrudFactory();
            crudReq = new RequisitosCrudFactory();
            crudReqBus = new RequisitoBusCrudFactory();
        }

        public RequisitoBus Create(RequisitoBus tmpRequisitos)
        {
            try
            {

                var missingFields = CheckMissingFields(tmpRequisitos, new string[] { "REQUISITO", "ID_REQUISITO_BUS" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));


                return tmpRequisitos = crudReqBus.Create(tmpRequisitos);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public void Delete(RequisitoBus tmpRequisitos)
        {
            try
            {

                crudReqBus.eliminar(tmpRequisitos);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<RequisitoBus> RetrieveAll()
        {
            try
            {
                var requisitos = crudReqBus.Listar();

                return requisitos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public RequisitoBus RetrieveById(RequisitoBus tmpRequisitos)
        {
            try
            {
                tmpRequisitos = crudReqBus.Retrieve(tmpRequisitos);

                return tmpRequisitos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public RequisitoBus Update(RequisitoBus tmpRequisitos)
        {
            try
            {

                return tmpRequisitos = crudReqBus.Update(tmpRequisitos);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}