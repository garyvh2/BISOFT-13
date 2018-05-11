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
    public class TraduccionPalabraController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/traduccion] POST
        public IHttpActionResult Post(TraduccionPalabra traduccionPalabra)
        {
            try
            {
                var manager = new TraduccionPalabraManager();
                
                manager.Create(traduccionPalabra);

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
