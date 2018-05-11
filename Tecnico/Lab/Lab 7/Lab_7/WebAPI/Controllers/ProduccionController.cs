using CoreAPI;
using Entidades;
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
    public class ProduccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/produccion] POST
        public IHttpActionResult Post(Produccion produccion)
        {
            try
            {
                var manager = new ProduccionManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(produccion);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read [api/produccion/{id}] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new ProduccionManager();
                var produccion = new Produccion
                {
                    Id = id
                };

                produccion = manager.RetrieveById(produccion);
                apiResp = new ApiResponse();
                apiResp.Data = produccion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List [api/produccion] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new ProduccionManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/produccion] PUT
        public IHttpActionResult Put(Produccion produccion)
        {
            try
            {
                var manager = new ProduccionManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(produccion);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/produccion] DELETE
        public IHttpActionResult Delete(Produccion produccion)
        {
            try
            {
                var manager = new ProduccionManager();
                manager.Delete(produccion);

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
