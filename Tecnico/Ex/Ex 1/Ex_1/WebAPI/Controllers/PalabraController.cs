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
    public class PalabraController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/palabra] POST
        public IHttpActionResult Post(Palabra palabra)
        {
            try
            {
                var manager = new PalabraManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(palabra);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read [api/palabra/{id}]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new PalabraManager();
                var palabra = new Palabra
                {
                    Id = id
                };

                palabra = manager.RetrieveById(palabra);
                apiResp = new ApiResponse();
                apiResp.Data = palabra;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read by Palabra [api/palabra/{id}]
        [HttpGet, Route("api/palabra/palabra/{inPalabra}")]
        public IHttpActionResult GetByPalabra(string inPalabra)
        {
            try
            {
                var manager = new PalabraManager();
                var palabra = new Palabra
                {
                    _Palabra = inPalabra
                };

                palabra = manager.RetrieveByPalabra(palabra);

                apiResp = new ApiResponse();
                apiResp.Data = palabra;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read by Familia & Idioma [api/palabra/]
        [HttpPost, Route("api/palabra/familia_idioma/")]
        public IHttpActionResult GetByFamiliaAndIdioma(Palabra palabra)
        {
            try
            {
                var manager = new PalabraManager();

                palabra = manager.RetrieveByFamiliaAndIdioma(palabra);

                apiResp = new ApiResponse();
                apiResp.Data = palabra;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List [api/palabra] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new PalabraManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List by Idioma [api/palabra/idioma/{id}] GET
        [HttpGet, Route("api/palabra/idioma/{id}")]
        public IHttpActionResult GetByIdioma(int id)
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new PalabraManager();
                apiResp.Data = manager.RetrieveAllByIdioma(new Idioma()
                {
                    Id = id
                });

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/palabra] PUT
        public IHttpActionResult Put(Palabra palabra)
        {
            try
            {
                var manager = new PalabraManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(palabra);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/palabra] DELETE
        public IHttpActionResult Delete(Palabra palabra)
        {
            try
            {
                var manager = new PalabraManager();
                manager.Delete(palabra);

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
        // >> Top100
        [HttpGet, Route("api/palabra/top100/")]
        public IHttpActionResult Top100()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new PalabraManager();
                apiResp.Data = manager.RetrieveTop100();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List by Idioma [api/palabra/idioma/{id}] GET
        [HttpGet, Route("api/palabra/top10dia/{dia}")]
        public IHttpActionResult Top10Dia(int dia)
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new PalabraManager();
                var palabra = new Palabra
                {
                    DiaSemana = dia
                };

                apiResp.Data = manager.RetrieveTop10Dia(palabra);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Top10
    }
}
