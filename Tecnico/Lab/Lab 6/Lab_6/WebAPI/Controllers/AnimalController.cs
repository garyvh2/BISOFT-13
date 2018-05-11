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
    public class AnimalController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create [api/animal] POST
        public IHttpActionResult Post(Animal animal)
        {
            try
            {
                var manager = new AnimalManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Create(animal);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Read [api/animal/{id}] GET
        public IHttpActionResult Get(int id)
        {
            try
            {
                var manager = new AnimalManager();
                var animal = new Animal
                {
                    Id = id
                };

                animal = manager.RetrieveById(animal);
                apiResp = new ApiResponse();
                apiResp.Data = animal;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> List [api/animal] GET
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();

                var manager = new AnimalManager();
                apiResp.Data = manager.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Update [api/animal] PUT
        public IHttpActionResult Put(Animal animal)
        {
            try
            {
                var manager = new AnimalManager();

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = manager.Update(animal);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.Message));
            }
        }
        // >> Delete [api/animal] DELETE
        public IHttpActionResult Delete(Animal animal)
        {
            try
            {
                var manager = new AnimalManager();
                manager.Delete(animal);

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
