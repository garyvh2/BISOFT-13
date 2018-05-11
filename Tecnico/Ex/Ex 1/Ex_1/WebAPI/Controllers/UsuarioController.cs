using CoreAPI.Managers;
using Entidades.Classes;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
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

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(usuario);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read [api/usuario/{id}] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new UsuarioManager();
                var usuario = new Usuario
                {
                    Id = id
                };

                usuario = manager.RetrieveById(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
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
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/usuario] PUT
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(usuario);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/usuario] DELETE
        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var manager = new UsuarioManager();
                manager.Delete(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
    }
}
