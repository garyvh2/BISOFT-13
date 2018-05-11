using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls.CtrlInputModel
{
    public class CtrlInputModel : CtrlBaseModel
    {
        // >> Properties
        public string   Title               { get; set; }
        public string   Type                { get; set; } = "text";
        public string   Disabled            { get; set; } = "";
        public string   Min                 { get; set; }
        public string   Max                 { get; set; }
        public string   Bootstrap_Classes   { get; set; }
        public string   Placeholder         { get; set; }
        public string   Value               { get; set; } = "";

        // >> Constructor
        public CtrlInputModel()
        {
        }
    }
}