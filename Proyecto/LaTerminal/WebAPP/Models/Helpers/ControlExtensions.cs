using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Models.Controls.CtrlButtonModel;
using WebAPP.Models.Controls.CtrlCheckRadioModel;
using WebAPP.Models.Controls.CtrlComboBoxModel;
using WebAPP.Models.Controls.CtrlInputModel;
using WebAPP.Models.Controls.CtrlTableModel;
using WebAPP.Helpers;
using WebAPP.Models.Controls.CtrlNavigation;
using WebAPP.Models.Controls.CtrlSubMenu;
using WebAPP.Models.Controls.CtrlTextAreaModel;
using Entities.Entities.ArchitectureEntities;
using WebAPP.Models.Controls.CtrlFooter;
using Entities.Classes;
using WebAPP.Models.Controls.CtrlFontAwesomePicker;
using WebAPP.Models.Controls.CtrlCardActivator;
using WebAPP.Models.Controls.CtrlImageUploader;
using Entities.Entities;
using WebAPP.Models.Controls.CtrlPayment;
using WebAPP.Models.Controls.CtrlTarjetas;
using WebAPP.Models.Controls.CtrlSelectSearch;
using System.Net.Http;

namespace WebAPP.Helpers
{
    // >> Class In Charge of Control Parametrization
    public static class ControlExtensions
    {
        // >> Tarjetas
        public static HtmlString CtrlTarjetas(this HtmlHelper html,
            Usuario Current_User)
        {
            var ctrl = new CtrlTarjetas()
            {
                Id = Guid.NewGuid().ToString(),
                Current_User = Current_User
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Navigation
        public static HtmlString CtrlNavigation(this HtmlHelper html,
            Usuario Current_User)
        {
            var ctrl = new CtrlNavigation()
            {
                Id = Guid.NewGuid().ToString(),
                Current_User = Current_User
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Payments
        public static HtmlString CtrlPayment(this HtmlHelper html)
        {
            var ctrl = new CtrlPayment()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Image Upload
        public static HtmlString CtrlImageUploader(this HtmlHelper html)
        {
            var ctrl = new CtrlImageUploader()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Card Activator
        public static HtmlString CtrlCardActivator(this HtmlHelper html)
        {
            var ctrl = new CtrlCardActivator()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Navigation
        public static HtmlString CtrlFooter(this HtmlHelper html)
        {
            var ctrl = new CtrlFooter()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Sub Menu
        public static HtmlString CtrlSubMenu(this HtmlHelper html)
        {
            var ctrl = new CtrlSubMenu()
            {
                Id = Guid.NewGuid().ToString()
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Invoke 
        public static HtmlString CtrlTable(this HtmlHelper html,
            string viewName,
            string id,
            string title,
            string columnsTitle,
            string ColumnsDataName,
            string FunctionName)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = FunctionName
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Input
        public static HtmlString CtrlInput(this HtmlHelper html,
            string Id,
            string Title,
            CtrlInputTypes Type,
            string Tooltip = "",
            string ColumnDataName = null,
            string Bootstrap_Clases = "",
            string Placeholder = "",
            string Disabled = null,
            string Min = "",
            string Max = "",
            string Value = "",
            bool Exclude = false)
        {
            var ctrl = new CtrlInputModel
            {
                Id = Id,
                Title = Title,
                Type = Type.ToString(),
                Tooltip = Tooltip,
                ColumnDataName = ColumnDataName ?? Id,
                Bootstrap_Classes = Bootstrap_Clases,
                Placeholder = Placeholder,
                Disabled = Disabled == null ? "" : "disabled",
                Min = Min,
                Max = Max,
                Value = Value,
                Exclude = Exclude ? "" : "ltl_input"
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Font Awesome Picker
        public static HtmlString CtrlFontAwesomePicker (this HtmlHelper html,
            string Id,
            string Title,
            string Disabled = null,
            string ColumnDataName = null,
            string Placeholder = "",
            string Value = "")
        {
            var ctrl = new CtrlFontAwesomePicker
            {
                Id = Id,
                Title = Title,
                ColumnDataName = ColumnDataName ?? Id,
                Placeholder = Placeholder,
                Disabled = Disabled == null ? "" : "disabled",
                Value = Value
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Combo Box
        public static HtmlString CtrlComboBox<T>(this HtmlHelper html,
            string Id,
            string Title,
            string ListId = null,
            string Service = null,
            string IdField = null,
            string DescriptionField = null,
            string ColumnDataName = null,
            List<T> Options = null, 
            string Multiple = null,
            string MultipleSubId = null,
            bool Placeholder = true,
            string Disabled = null,
            bool Default = false) where T : BaseEntity
        {
            var ctrl = new CtrlComboBoxModel<T>
            {
                Id = Id,
                Title = Title,
                ListId = ListId,
                ColumnDataName = ColumnDataName ?? Id,
                IdField = IdField ?? "Valor",
                DescriptionField = DescriptionField ?? "Descripcion",
                Service = Service ?? "list",
                Options = Options ?? new List<T>(),
                Disabled = Disabled == null ? "" : "disabled",
                Multiple = Multiple == null ? "" : "multiple",
                MultipleSubId = MultipleSubId ?? "",
                Placeholder = Placeholder,
                Default = Default
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Select Search
        // >> Combo Box
        public static HtmlString CtrlSelectSearch<T>(this HtmlHelper html,
            string Id,
            string Title,
            string ListId = null,
            string Service = null,
            string IdField = null,
            string DescriptionField = null,
            string ColumnDataName = null,
            List<T> Options = null,
            string Disabled = null,
            string Create = null,
            Usuario Current_User = null,
            string Method = null,
            bool Default = false) where T : BaseEntity
        {
            var ctrl = new CtrlSelectSearch<T>
            {
                Id = Id,
                Title = Title,
                ListId = ListId,
                ColumnDataName = ColumnDataName ?? Id,
                IdField = IdField ?? "Valor",
                DescriptionField = DescriptionField ?? "Descripcion",
                Service = Service ?? "list",
                Options = Options ?? new List<T>(),
                Disabled = Disabled == null ? "" : "disabled",
                Create = Create == null ? "" : "d-none",
                Current_User = Current_User,
                Method = Method ?? "GET"
            };

            return new HtmlString(ctrl.GetHtml());
        }
        // >> Buttom
        public static HtmlString CtrlButton(this HtmlHelper html,
            string viewName,
            string Id,
            string Title,
            string FunctionName,
            string Disabled = null,
            string CustomService = null,
            bool IncludeSession = false,
            string Bootstrap_Classes = "btn-primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = Id,
                Title = Title,
                FunctionName = FunctionName,
                CustomService = (CustomService ?? "undefined") + ",",
                IncludeSession = IncludeSession ? "true" : "false",
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

        //Textarea
        public static HtmlString CtrlTextarea(this HtmlHelper html,
            string Id,
            string Title,
            CtrlInputTypes Type,
            string ColumnDataName = null,
            string Bootstrap_Clases = "",
            string Placeholder = null,
            string Disabled = null,
            string Min = null,
            string Max = null,
            string Value = null)
        {

            var ctrl = new CtrlTextAreaModel
            {
                Id = Id,
                Title = Title,
                Type = Type == CtrlInputTypes.DATETIME ? "datetime-local" : Type.ToString(),
                ColumnDataName = ColumnDataName ?? Id,
                Bootstrap_Classes = Bootstrap_Clases,
                Placeholder = Placeholder ?? "",
                Disabled = Disabled == null ? "" : "disabled",
                Min = Min ?? "",
                Max = Max ?? "",
                Value = Value ?? ""
            };

            return new HtmlString(ctrl.GetHtml());
        }

        // >> CheckBox / Radio con funcion de onCLick
        public static HtmlString CtrlCheckRadio(this HtmlHelper html,
            string Id,
            string Title,
            string Name,
            string onCLickFunction,
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