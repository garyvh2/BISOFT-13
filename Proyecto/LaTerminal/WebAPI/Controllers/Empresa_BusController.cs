using CoreAPI.Managers;
using Entities.Classes;
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
    public class Empresa_BusController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Empresa_Bus empresa_Bus)
        {
            try
            {
                var manager = new Empresa_BusManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(empresa_Bus)
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
                var manager = new Empresa_BusManager();
                var empresa_Bus = new Empresa_Bus()
                {
                    CEDULA_JUR = id
                };

                empresa_Bus = manager.RetrieveById(empresa_Bus);
                apiResp = new ApiResponse
                {
                    Data = empresa_Bus
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

                var manager = new Empresa_BusManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Empresa_Bus empresa_Bus)
        {
            try
            {
                var manager = new Empresa_BusManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(empresa_Bus)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Empresa_Bus empresa_Bus)
        {
            try
            {
                var manager = new Empresa_BusManager();
                manager.Delete(empresa_Bus);

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
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List [api/example] GET
        [HttpPost,      Route("api/empresa_bus/terminal")]
        public IHttpActionResult AsignarATerminal(Empresa_Bus empresa_Bus)
        {
            try
            {
                var manager = new Empresa_BusManager();

                manager.AsignarATerminal(empresa_Bus);
                apiResp = new ApiResponse
                {
                    Message = "Asignada Correctamente"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [HttpDelete,    Route("api/empresa_bus/terminal")]
        public IHttpActionResult DesasignarATerminal(Empresa_Bus empresa_Bus)
        {
            try
            {
                var manager = new Empresa_BusManager();

                manager.DeasignarDeTerminal(empresa_Bus);
                apiResp = new ApiResponse
                {
                    Message = "Desasignada Correctamente"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [HttpGet,       Route("api/empresa_bus/terminal")]
        public IHttpActionResult GetGroupedByTerminal()
        {
            try
            {
                var manager = new Empresa_BusManager();
                apiResp = new ApiResponse
                {
                    Data = manager.RetrieveAllGroupedByTerminal()
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