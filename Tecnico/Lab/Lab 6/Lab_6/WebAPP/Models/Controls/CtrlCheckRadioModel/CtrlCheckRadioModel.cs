using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Helpers;

namespace WebAPP.Models.Controls.CtrlCheckRadioModel
{
    public class CtrlCheckRadioModel : CtrlBaseModel
    {
        public CtrlCheckRadioModel()
        {
        }

        public string   Title       { get; set; }
        public string   Type        { get; set; }
        public string   Name        { get; set; }
        public string   Checked     { get; set; }


    }
}