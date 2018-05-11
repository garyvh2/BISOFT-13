using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class OperacionesController : ApiController
    {
        // POST: api/Operaciones
        [HttpPost, Route("api/post")]
        public HttpResponseMessage Post([FromBody]Operacion operacion)
        {
            operacion = operacion.procesar(operacion);

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonConvert.SerializeObject(operacion))
            };

            return response;
        }
    }
}
