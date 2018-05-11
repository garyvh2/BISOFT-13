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
    public class IdiomaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/idioma] POST
        public IHttpActionResult Post(Idioma idioma)
        {
            try
            {
                var manager = new IdiomaManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(idioma);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read [api/idioma/{id}] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new IdiomaManager();
                var idioma = new Idioma
                {
                    Id = id
                };

                idioma = manager.RetrieveById(idioma);
                apiResp = new ApiResponse();
                apiResp.Data = idioma;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List [api/idioma] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new IdiomaManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/idioma] PUT
        public IHttpActionResult Put(Idioma idioma)
        {
            try
            {
                var manager = new IdiomaManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(idioma);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/idioma] DELETE
        public IHttpActionResult Delete(Idioma idioma)
        {
            try
            {
                var manager = new IdiomaManager();
                manager.Delete(idioma);

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
        // >> List [api/idioma] GET
        [HttpGet, Route("api/idioma/mas_popular")]
        public IHttpActionResult MasPopular()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new IdiomaManager();
                apiResp.Data = manager.RetrieveMasPopular();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
    }
}
