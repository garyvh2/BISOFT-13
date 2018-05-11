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
    public class ProductoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new ProductoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                apiResp = new ApiResponse();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST api/values
        public IHttpActionResult Post(Producto producto)
        {
            try
            {
                apiResp = new ApiResponse();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put(Producto producto)
        {
            try
            {
                apiResp = new ApiResponse();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(Producto producto)
        {
            try
            {
                apiResp = new ApiResponse();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
