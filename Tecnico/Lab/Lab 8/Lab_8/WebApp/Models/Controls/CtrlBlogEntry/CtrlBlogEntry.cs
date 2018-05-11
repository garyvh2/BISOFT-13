using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebAPP.Models.Controls;

namespace WebApp.Models.Controls.CtrlBlog
{
    public class CtrlBlogEntry : CtrlBaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int Replies { get; set; }
        public string Image { get; set; }

        private DateTime _PublishedDate;
        public string PublishedDate {
            get
            {
                return _PublishedDate.ToString("yyyy MM dd - HH:mm:ss");
            }
            set
            {
                this._PublishedDate = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture);
            }

        }

        public CtrlBlogEntry ()
        {

        }
    }
}
