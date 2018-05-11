using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Models.Controls.CtrlButtonModel;
using WebAPP.Models.Controls.CtrlCheckRadioModel;
using WebAPP.Models.Controls.CtrlComboBox;
using WebAPP.Models.Controls.CtrlInputModel;
using WebAPP.Models.Controls.CtrlTable;
using WebAPP.Helpers;

namespace WebAPP.Helpers
{
    // >> Class In Charge of Control Parametrization
    public static class ControlExtensions
    {
        // >> Invoke 
        public static HtmlString CtrlTable(this HtmlHelper html, string id, string title,
            string columnsTitle, string ColumnsDataName)
        {
            var ctrl = new CtrlTableModel
            {
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Input
        public static HtmlString CtrlInput (this HtmlHelper html, 
            string Id, 
            string Title,
            CtrlInputTypes Type,
            string Bootstrap_Clases = "",
            string Placeholder = null,
            string Disabled = null,
            string Min      = null,
            string Max      = null,
            string Value    = null)
        {
            var ctrl = new CtrlInputModel
            {
                Id                  = Id,
                Title               = Title,
                Type                = Type.ToString(),
                Bootstrap_Classes   = Bootstrap_Clases,
                Placeholder         = Placeholder   == null ? "" : Placeholder,
                Disabled            = Disabled      == null ? "" : "disabled",
                Min                 = Min           == null ? "" : Min,
                Max                 = Max           == null ? "" : Max,
                Value               = Value         == null ? "" : Value
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Combo Box
        public static HtmlString CtrlComboBox(this HtmlHelper html,
            string Id,
            string Title,
            List<CtrlOptionModel> Options,
            string Multiple = null)
        {
            var ctrl = new CtrlComboBoxModel
            {
                Id = Id,
                Title = Title,
                Options = Options,
                Multiple = Multiple == null ? "" : "multiple"
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Buttom
        public static HtmlString CtrlButton(this HtmlHelper html,
            string Id,
            string Title,
            string Disabled = null,
            string Bootstrap_Classes = "btn-primary")
        {
            var ctrl = new CtrlButtonModel
            {
                Id = Id,
                Title = Title,
                Disabled = Disabled == null ? "" : "disabled",
                Bootstrap_Classes = Bootstrap_Classes
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> CheckBox / Radio
        public static HtmlString CtrlCheckRadio(this HtmlHelper html,
            string Id,
            string Title,
            string Name,
            CtrlCheckRadioTypes Type = CtrlCheckRadioTypes.CHECKBOX,
            string Checked = null)
        {
            var ctrl = new CtrlCheckRadioModel
            {
                Id = Id,
                Title = Title,
                Name = Name,
                Type = Type.ToString(),
                Checked = Checked == null ? "" : "checked"
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}