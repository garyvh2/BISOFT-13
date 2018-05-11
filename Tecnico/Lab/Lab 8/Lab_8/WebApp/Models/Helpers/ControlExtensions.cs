using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls.CtrlBlog;
using WebApp.Models.Controls.CtrlBlogContent;

namespace WebAPP.Helpers
{
    // >> Class In Charge of Control Parametrization
    public static class ControlExtensions
    {
        // >> Navigation
        public static HtmlString CtrlBlog(this HtmlHelper html)
        {
            var ctrl = new CtrlBlog()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Navigation
        public static HtmlString CtrlBlogContent(this HtmlHelper html)
        {
            var ctrl = new CtrlBlogContent()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}