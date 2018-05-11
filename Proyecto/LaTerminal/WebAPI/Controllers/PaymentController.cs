using CoreAPI.Integrations;
using CoreAPI.Integrations.Models;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PaymentController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        [HttpGet, Route("api/payments/token")]
        public IHttpActionResult Token()
        {
            try
            {
                var token = PaymentManager.GetInstance().GetToken().ClientToken.Generate();

                apiResp = new ApiResponse
                {
                    Message = "Generado",
                    Data = token
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/payments/pay")]
        public IHttpActionResult Pay (Payment payment)
        {
            try
            {
                PaymentManager.GetInstance().Pay(payment);

                apiResp = new ApiResponse
                {
                    Message = "El pago fue recibido"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/payments/pay/tarjeta")]
        public IHttpActionResult PagarTarjeta (PaymentObject<Tarjeta> paymentObject)
        {
            try
            {
                TransaccionManager.GetInstance().PagarTarjeta(paymentObject);

                apiResp = new ApiResponse
                {
                    Message = "El pago fue recibido"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/payments/pay/sancion")]
        public IHttpActionResult PagarSancion (PaymentObject<Sancion> paymentObject)
        {
            try
            {


                apiResp = new ApiResponse
                {
                    Message = "El pago fue recibido"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/payments/pay/recarga")]
        public IHttpActionResult PagarRecarga (PaymentObject<Tarjeta> paymentObject)
        {
            try
            {
                TransaccionManager.GetInstance().PagarRecarga(paymentObject);


                apiResp = new ApiResponse
                {
                    Message = "El pago fue recibido"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/payments/pay/pasaje")]
        public IHttpActionResult PagarPasaje (PaymentObject<Tarjeta> paymentObject)
        {
            try
            {


                apiResp = new ApiResponse
                {
                    Message = "El pago fue recibido"
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
