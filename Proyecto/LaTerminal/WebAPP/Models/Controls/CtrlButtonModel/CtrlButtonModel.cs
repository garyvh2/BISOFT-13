using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls.CtrlButtonModel
{
    public class CtrlButtonModel : CtrlBaseModel
    {
        // >> Properties
        public string Title { get; set; }
        public string CustomService { get; set; }
        public string IncludeSession { get; set; } = "false";
        public string FunctionName { get; set; }
        public string Disabled { get; set; }
        public string Bootstrap_Classes { get; set; } = "btn-primary";

        // >> Constructor
        public CtrlButtonModel()
        {
        }
    }
}