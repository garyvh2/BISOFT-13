using CoreAPI.Managers;
using Entities.Classes;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HorariosController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/example] POST
        public IHttpActionResult Post(Horarios Horarios)
        {
            try
            {
                var manager = new HorariosManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Create(Horarios);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Read [api/example/{id}] GET
        public IHttpActionResult Get(string id)
        {
            try
            {
                var manager = new HorariosManager();
                var Horarios = new Horarios()
                {
                    Id = id
                };

                Horarios = manager.RetrieveById(Horarios);
                apiResp = new ApiResponse();
                apiResp.Data = Horarios;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> List [api/example] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new HorariosManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Update [api/example] PUT
        public IHttpActionResult Put(Horarios Horarios)
        {
            try
            {
                var manager = new HorariosManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";
                apiResp.Data = manager.Update(Horarios);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >> Delete [api/example] DELETE
        public IHttpActionResult Delete(Horarios Horarios)
        {
            try
            {
                var manager = new HorariosManager();
                manager.Delete(Horarios);

                apiResp = new ApiResponse();
                apiResp.Message = "Solicitud procesada correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Mensaje));
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List [api/example] GET

    }
}