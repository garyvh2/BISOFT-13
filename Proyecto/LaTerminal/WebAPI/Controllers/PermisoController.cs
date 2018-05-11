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
    public class PermisoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Permiso Permiso)
        {
            try
            {
                var manager = new PermisoManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(Permiso)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new PermisoManager();
                var Permiso = new Permiso()
                {
                    Id = id
                };

                Permiso = manager.RetrieveById(Permiso);
                apiResp = new ApiResponse
                {
                    Data = Permiso
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

                var manager = new PermisoManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Permiso Permiso)
        {
            try
            {
                var manager = new PermisoManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(Permiso)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Permiso Permiso)
        {
            try
            {
                var manager = new PermisoManager();
                manager.Delete(Permiso);

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
        // >> Read [api/permiso/rol/{id}] GET
        [Route("api/permiso/rol/{id}")]
        public IHttpActionResult GetByRol(string id)
        {
            try
            {
                var manager = new PermisoManager();
                var Rol = new Rol()
                {
                    Id = id
                };

                apiResp = new ApiResponse
                {
                    Data = manager.RetrieveAllByRol(Rol)
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
