using CoreAPI.Managers.ArchitectureComponents;
using Entities.Entities.ArchitectureEntities;
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
    public class ConfiguracionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(ConfigurationItem configuration)
        {
            try
            {
                var manager = new ConfigurationManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Create(configuration)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(string codigo)
        {
            try
            {
                var manager = new ConfigurationManager();
                var configuration = new ConfigurationItem()
                {
                    Codigo = codigo
                };

                configuration = manager.RetrieveById(configuration);
                apiResp = new ApiResponse
                {
                    Data = configuration
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

                var manager = new ConfigurationManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(ConfigurationItem configuration)
        {
            try
            {
                var manager = new ConfigurationManager();

                apiResp = new ApiResponse
                {
                    Message = "Solicitud procesada correctamente.",
                    Data = manager.Update(configuration)
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(ConfigurationItem configuration)
        {
            try
            {
                var manager = new ConfigurationManager();
                manager.Delete(configuration);

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
    }
}
