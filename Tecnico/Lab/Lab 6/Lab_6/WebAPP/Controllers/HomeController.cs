using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnimalesView()
        {
            return View("~/Views/Home/AnimalesView/AnimalesView.cshtml");
        }

        public ActionResult ProduccionView()
        {
            return View("~/Views/Home/ProduccionView/ProduccionView.cshtml");
        }

        public ActionResult ProductosView()
        {
            return View("~/Views/Home/ProductosView/ProductosView.cshtml");
        }

        public ActionResult PedidosView()
        {
            return View("~/Views/Home/PedidosView/PedidosView.cshtml");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}