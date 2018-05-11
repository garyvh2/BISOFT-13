using Cliente.Lib.Requester;
using Entities.Entities;
using Entities.Entities.ArchitectureEntities;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using WebAPP.Models.Controls;

namespace WebAPP.Controllers
{
    public class WebServiceController : ApiController
    {
        private string URL_API = ConfigurationManager.AppSettings["API_BASE_URL"];
        public HttpSessionState Session { get; }


        [Route("api/usuario/login")]
        public IHttpActionResult Login(Usuario usuario)
        {
            try
            {
                RequestReponse<Usuario> response = new RequestReponse<Usuario>();
                // >> Request
                var req = new RequestParams()
                {
                    Url = URL_API + "usuario/login",
                    Method = HttpMethod.Post,
                    Body = usuario
                };
                new Request(req).Run<Usuario>(data =>
                {
                    response = data;
                });

                HttpContext.Current.Session.Add("current_user", response.Data);

                return Ok(response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/usuario/logout")]
        public IHttpActionResult Logout()
        {
            try
            {
                HttpContext.Current.Session.Clear();

                return Ok(new RequestReponse<Usuario>() {
                    Message     = "Closed",
                    Data        = null
                    
                });
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/usuario/refresh")]
        public IHttpActionResult UsuarioRefresh(Usuario usuario)
        {
            try
            {
                RequestReponse<Usuario> response = new RequestReponse<Usuario>();
                // >> Request
                var req = new RequestParams()
                {
                    Url = URL_API + "usuario/" + usuario.Identificacion,
                    Method = HttpMethod.Get
                };
                new Request(req).Run<Usuario>(data =>
                {
                    response = data;
                });

                HttpContext.Current.Session.Add("current_user", response.Data);

                return Ok(response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        [Route("api/configuracion/refresh")]
        public IHttpActionResult ConfiguracionRefresh()
        {
            try
            {
                RequestReponse<List<ConfigurationItem>> response = new RequestReponse<List<ConfigurationItem>>();
                // >> Request
                var req = new RequestParams()
                {
                    Url = URL_API + "configuracion",
                    Method = HttpMethod.Get
                };
                new Request(req).Run<List<ConfigurationItem>>(data =>
                {
                    response = data;
                });

                HttpContext.Current.Session.Add("configuracion", response.Data);

                return Ok(response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
    }
}
