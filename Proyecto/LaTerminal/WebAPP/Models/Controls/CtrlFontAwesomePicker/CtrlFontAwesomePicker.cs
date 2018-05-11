using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls.CtrlFontAwesomePicker
{
    public class CtrlFontAwesomePicker : CtrlBaseModel
    {
        // >> Properties
        public string Title { get; set; }
        public string Disabled { get; set; } = "";
        public string Placeholder { get; set; }
        public string Value { get; set; } = "";

        // >> Constructor
        public CtrlFontAwesomePicker()
        {
        }
    }
}