using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPP.Controllers
{
    public class AdminScreenController : Controller
    {
        // >> Usuarios
        [Route("CRUD/Usuario")]
        public ActionResult Usuario()
        {
            return View("~/Views/AdminScreen/Usuario/Usuario.cshtml");
        }
        // >> Rol
        [Route("CRUD/Rol")]
        public ActionResult Rol()
        {
            return View("~/Views/AdminScreen/Rol/Rol.cshtml");
        }
        // >> Permisos
        [Route("CRUD/Permiso")]
        public ActionResult Permiso()
        {
            return View("~/Views/AdminScreen/Permiso/Permiso.cshtml");
        }
        // >> Terminales
        [Route("CRUD/Terminal")]
        public ActionResult Terminal()
        {
            return View("~/Views/AdminScreen/Terminal/Terminal.cshtml");
        }
        // >> Sancion
        [Route("CRUD/Sancion")]
        public ActionResult Sancion()
        {
            return View("~/Views/AdminScreen/Sancion/Sancion.cshtml");
        }
        // >> Quejas
        [Route("CRUD/Queja")]
        public ActionResult Queja()
        {
            return View("~/Views/AdminScreen/Queja/Queja.cshtml");
        }
        // >> Tarjeta
        [Route("CRUD/Tarjeta")]
        public ActionResult Tarjeta()
        {
            return View("~/Views/AdminScreen/Tarjeta/Tarjeta.cshtml");
        }
        // >> Empresa de bus
        [Route("CRUD/Empresa_Bus")]
        public ActionResult Empresa_Bus()
        {
            return View("~/Views/AdminScreen/Empresa_Bus/Empresa_Bus.cshtml");
        }
        // >> TipoTarjeta
        [Route("CRUD/TipoTarjeta")]
        public ActionResult TipoTarjeta()
        {
            return View("~/Views/AdminScreen/TipoTarjeta/TipoTarjeta.cshtml");
        }
        // >> Buses
        [Route("CRUD/Buses")]
        public ActionResult Buses()
        {
            return View("~/Views/AdminScreen/Buses/Buses.cshtml");
        }
        // >> Asignar Empresa a terminal
        [Route("Asignacion/Empresa")]
        public ActionResult EmpresaTerminal()
        {
            return View("~/Views/AdminScreen/AsignarEmpresaTerminal/AsignarEmpresaTerminal.cshtml");
        }
        // >> Asignar Bus a Horario
        [Route("Asignacion/Bus")]
        public ActionResult BusHorarioRuta()
        {
            return View("~/Views/AdminScreen/AsignarBusHorario/AsignarBusHorario.cshtml");
        }
        // >> Requisitos
        [Route("Crud/Requsitos")]
        public ActionResult Requisitos()
        {
            return View("~/Views/AdminScreen/Requisitos/Requisitos.cshtml");
        }
        // >> Administrar Requisitos
        [Route("Administracion/RequisitosBus")]
        public ActionResult RequisitoBus()
        {
            return View("~/Views/AdminScreen/RequisitosDeBuses/RequisitosDeBuses.cshtml");
        }
        // >> Administrar Requisitos
        [Route("AprobarUsuarioJuridico")]
        public ActionResult AprobarUsuarioJuridico()
        {
            return View("~/Views/AdminScreen/AprobarUsuarioJuridico/AprobarUsuarioJuridico.cshtml");
        }
    }
}
