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
    public class TarjetaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Tarjeta tmpTarjeta)
        {
            try
            {
                var manager = new TarjetaManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(tmpTarjeta)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(String id)
        {
            try
            {
                var manager = new TarjetaManager();
                var tmpTarjeta = new Tarjeta
                {
                    Codigo = id
                };

                tmpTarjeta = manager.RetrieveById(tmpTarjeta);
                apiResp = new ApiResponse
                {
                    Data = tmpTarjeta
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

                var manager = new TarjetaManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Tarjeta tmpTarjeta)
        {
            try
            {
                var manager = new TarjetaManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(tmpTarjeta)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Tarjeta tmpTarjeta)
        {
            try
            {
                var manager = new TarjetaManager();
                manager.Delete(tmpTarjeta);

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
        // >> List [api/usuario] GET
        [Route("api/tarjeta/activate")]
        public IHttpActionResult Activate(Tarjeta tarjeta)
        {
            try
            {
                var manager = new TarjetaManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Activate(tarjeta)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> By Usuario
        [Route("api/tarjeta/usuario")]
        public IHttpActionResult ByUsuario(Tarjeta tarjeta)
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new TarjetaManager();
                apiResp.Data = manager.RetrieveAllByUsuario(tarjeta);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
    }
}
