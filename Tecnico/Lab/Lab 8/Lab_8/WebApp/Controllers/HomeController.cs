using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult SearchBlogs()
        {
            return View("~/Views/Home/SearchBlogs/SearchBlogs.cshtml");
        }
    }
}