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
    public class TraduccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/traduccion] POST
        public IHttpActionResult Post(Traduccion traduccion)
        {
            try
            {
                var manager = new TraduccionManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(traduccion);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Get [api/traduccion/] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new TraduccionManager();
                var traduccion = new Traduccion
                {
                    Id = id
                };

                traduccion = manager.RetrieveById(traduccion);
                apiResp = new ApiResponse();
                apiResp.Data = traduccion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List [api/traduccion] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new TraduccionManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/traduccion] PUT
        public IHttpActionResult Put(Traduccion traduccion)
        {
            try
            {
                var manager = new TraduccionManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(traduccion);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/traduccion] DELETE
        public IHttpActionResult Delete(Traduccion traduccion)
        {
            try
            {
                var manager = new TraduccionManager();
                manager.Delete(traduccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Calcular Popularidad [api/traduccion/popularidad] PUT
        [HttpPut, Route("api/traduccion/popularidad")]
        public IHttpActionResult CalcularPopularidad(Traduccion traduccion)
        {
            try
            {
                var manager = new TraduccionManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.CalcularPopularidad(traduccion);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
    }
}
