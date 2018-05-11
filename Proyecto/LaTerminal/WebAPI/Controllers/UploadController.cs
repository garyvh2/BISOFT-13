using CoreAPI.Integrations;
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
    public class UploadController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        [Route("api/image/user"), AllowAnonymous]
        public IHttpActionResult UploadUserImage()
        {
            try
            {
                // HTTP Request
                var httpRequest = HttpContext.Current.Request;

                var manager = new UploadManager();
                manager.UploadImage(httpRequest, "user");

                apiResp = new ApiResponse
                {
                    Message = "Imagen actualizada con éxito."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/image/logo"), AllowAnonymous]
        public IHttpActionResult UploadLogoImage()
        {
            try
            {
                // HTTP Request
                var httpRequest = HttpContext.Current.Request;

                var manager = new UploadManager();
                manager.UploadImage(httpRequest, "logo");

                apiResp = new ApiResponse
                {
                    Message = "Imagen actualizada con éxito."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }

        [Route("api/image/user/{id}"), AllowAnonymous]
        public HttpResponseMessage GetImage(string id)
        {
            try
            {
                // HTTP Request
                var httpRequest = HttpContext.Current.Request;

                var manager = new UploadManager();
                var image = manager.GetImage("user", id);



                return image;
            }
            catch (BussinessException bex)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                message.Content = new StringContent(bex.ExceptionId + " - " + bex.AppMessage.Mensaje);
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");
                message.StatusCode = HttpStatusCode.InternalServerError;
                return message;
            }
        }
    }
}
