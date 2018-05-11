using CoreAPI;
using Entidades;
using Entidades.Enums;
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
    public class PedidoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new PedidoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new PedidoManager();
                var pedido = new Pedido
                {
                    Id = id
                };

                pedido = mng.RetrieveById(pedido);
                apiResp = new ApiResponse();
                apiResp.Data = pedido;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST api/values
        public IHttpActionResult Post(Pedido pedido)
        {

            try
            {
                var mng = new PedidoManager();
                mng.Create(pedido);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put(Pedido pedido)
        {
            try
            {
                var mng = new PedidoManager();
                mng.Update(pedido);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(Pedido Pedido)
        {
            try
            {
                var mng = new PedidoManager();
                mng.Delete(Pedido);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
