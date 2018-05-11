using CoreAPI.Managers;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RequisitosController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Requisitos tmpRequisitos)
        {
            try
            {
                var manager = new RequisitosManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(tmpRequisitos)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(string id)
        {
            try
            {
                var manager = new RequisitosManager();
                var tmpRequisitos = new Requisitos
                {
                    NOMBRE = id
                };

                tmpRequisitos = manager.RetrieveById(tmpRequisitos);
                apiResp = new ApiResponse
                {
                    Data = tmpRequisitos
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> List [api/example] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new RequisitosManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Requisitos tmpRequisitos)
        {
            try
            {
                var manager = new RequisitosManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(tmpRequisitos)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Requisitos tmpRequisitos)
        {
            try
            {
                var manager = new RequisitosManager();
                manager.Delete(tmpRequisitos);

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
    }
}
