using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls.CtrlCheckRadioModel
{
    public class CtrlCheckRadioModel : CtrlBaseModel
    {
        // >> Properties
        public string Title { get; set; }
        public string Type { get; set; }
        public string Checked { get; set; }

        // >> Constructor
        public CtrlCheckRadioModel()
        {
        }

    }
}