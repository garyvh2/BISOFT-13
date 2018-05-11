using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls.CtrlComboBox
{
    public class CtrlComboBoxModel : CtrlBaseModel
    {
        public CtrlComboBoxModel()
        {
        }

        public string                   Title       { get; set; }
        public string                   Multiple    { get; set; }
        public List<CtrlOptionModel>    Options     { get; set; }
        

        public string DisplayOptions
        {
            get
            {
                var headers = "";
                Options.ForEach(option =>
                {
                    headers += $"<option value='{option.Value}'>{option.Text}</option>";
                });
                return headers;
            }
        }

    }
}