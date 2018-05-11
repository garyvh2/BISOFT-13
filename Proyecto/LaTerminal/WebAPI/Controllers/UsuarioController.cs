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
    //TODO Remove Clave_Salt
    public class UsuarioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/usuario] POST
        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(usuario)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/usuario/{id}] GET
        [Route("api/usuario/{Identificacion}")]
        public IHttpActionResult Get(string Identificacion)
        {
            try
            {
                var manager = new UsuarioManager();
                var usuario = new Usuario
                {
                    Identificacion = Identificacion
                };

                usuario = manager.RetrieveById(usuario);
                apiResp = new ApiResponse
                {
                    Data = usuario
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> List [api/usuario] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new UsuarioManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/usuario] PUT
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(usuario)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/usuario] DELETE
        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();
                manager.Delete(usuario);

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
        [Route("api/usuario/login")]
        public IHttpActionResult Login(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Login(usuario)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/usuario/recover")]
        public IHttpActionResult Recover(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse
                {
                    Message = "Revise su correo electrónico",
                    Data = manager.Recover(usuario)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [HttpPut, Route("api/usuario/clave")]
        public IHttpActionResult ActualizarClave(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse
                {
                    Message = "Actualizada Correctamente",
                    Data = manager.ActualizarClave(usuario)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [HttpGet, Route("api/usuario/rol/{Id_Rol}")]
        public IHttpActionResult GetByRol(string Id_Rol)
        {
            try
            {
                var manager = new UsuarioManager();
                var usuario = new Usuario
                {
                    Id_Rol = Id_Rol
                };


                apiResp = new ApiResponse
                {
                    Data = manager.RetrieveAllByRol(usuario)
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [HttpPost, Route("api/usuario/terminal_empresa")]
        public IHttpActionResult GetByTerminalOrEmpresa(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();
                apiResp = new ApiResponse
                {
                    Data = manager.RetrieveAllByTerminalOrEmpresa(usuario)
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
