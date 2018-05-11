using CoreAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPP.Controllers
{
    public class HomeScreenController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/HomeScreen/Index/Index.cshtml");
        }
        public ActionResult Estacionamiento()
        {
            return View("~/Views/Core/Estacionamiento/Estacionamiento.cshtml");

        }

     
        public ActionResult RegistrarSancionView()
        {
            return View("~/Views/Home/SancionView/RegistrarSancionView.cshtml");
        }

        public ActionResult ListarSancionView()
        {
            SancionManager manager = new SancionManager();

            //var lista = manager.RetriveAll();
            //ViewData["opciones"]
            return View("~/Views/Home/SancionView/ListarSancionView.cshtml");
        }
    }
}