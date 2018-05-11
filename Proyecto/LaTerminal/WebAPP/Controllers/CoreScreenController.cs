using Cliente.Lib.Requester;
using CoreAPI.Managers;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace WebAPP.Controllers
{
    public class CoreScreenController : Controller
    {
        // GET: CoreScreen
        public ActionResult Sancion()
        {
            return View("~/Views/Home/SancionView/RegistrarSancionView.cshtml");
        }

        [Route("Home")]
        public ActionResult HomeMenu()
        {
            return View("~/Views/CoreScreen/HomeMenu/HomeMenu.cshtml");
        }

        [Route("Perfil")]
        public ActionResult Perfil()
        {
            return View("~/Views/CoreScreen/Perfil/Perfil.cshtml");
        }
        [Route("Lista/Tarjetas")]
        public ActionResult ListaTarjetas()
        {
            return View("~/Views/CoreScreen/ListaTarjetas/ListaTarjetas.cshtml");
        }
        [Route("Compra/Tarjeta")]
        public ActionResult ComprarTarjeta()
        {
            return View("~/Views/CoreScreen/ComprarTarjeta/ComprarTarjeta.cshtml");
        }
        [Route("Lista/Transacciones")]
        public ActionResult ListaTransacciones()
        {
            return View("~/Views/CoreScreen/ListaTransacciones/ListaTransacciones.cshtml");
        }
        [Route("Usuario/RegistrarEmpleado")]
        public ActionResult RegistrarEmpleado()
        {
            return View("~/Views/CoreScreen/RegistrarEmpleado/RegistrarEmpleado.cshtml");
        }
    }
}
