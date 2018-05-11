using CoreAPI.Managers;
using Entities.Classes;
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
    public class RutaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Ruta Ruta)
        {
            try
            {
                var manager = new RutaManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Create(Ruta);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(string Numero_Ruta)
        {
            try
            {
                var manager = new RutaManager();
                var Ruta = new Ruta()
                {
                    Numero_Ruta = Numero_Ruta
                };

                Ruta = manager.RetrieveById(Ruta);
                apiResp = new ApiResponse();
                apiResp.Data = Ruta;
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

                var manager = new RutaManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Ruta Ruta)
        {
            try
            {
                var manager = new RutaManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Update(Ruta);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Ruta Ruta)
        {
            try
            {
                var manager = new RutaManager();
                manager.Delete(Ruta);

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";

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

    }
}