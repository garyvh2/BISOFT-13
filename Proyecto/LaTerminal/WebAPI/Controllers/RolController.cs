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
    public class RolController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Rol Rol)
        {
            try
            {
                var manager = new RolManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Create(Rol);

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
                var manager = new RolManager();
                var Rol = new Rol()
                {
                    Id = id
                };

                Rol = manager.RetrieveById(Rol);
                apiResp = new ApiResponse();
                apiResp.Data = Rol;
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

                var manager = new RolManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Rol Rol)
        {
            try
            {
                var manager = new RolManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Update(Rol);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Rol Rol)
        {
            try
            {
                var manager = new RolManager();
                manager.Delete(Rol);

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
