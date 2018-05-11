using Entities.Classes;
using Entities.Entities;
using Entities.Entities.ArchitectureEntities;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPP.Models.Controls.CtrlComboBoxModel
{
    public class CtrlComboBoxModel<T> : CtrlBaseModel where T : BaseEntity
    {
        public CtrlComboBoxModel()
        {
            Name = "CtrlComboBoxModel";
        }

        public string Title { get; set; }
        public string Multiple { get; set; }
        public string MultipleSubId { get; set; }
        public string ListId { get; set; }
        public string Disabled { get; set; } = "";
        public string Service { get; set; } = "list";
        public string IdField { get; set; } = "Valor";
        public string DescriptionField { get; set; } = "Descripcion";
        public bool Placeholder { get; set; }
        public bool Default { get; set; }
        private List<T> _Options;



        private string URL_API_LISTs = ConfigurationManager.AppSettings["API_BASE_URL"];


        public List<T> Options
        {
            get
            {
                if (ListId != null)
                {
                    return GetOptionsFromAPI();
                }
                else
                {
                    return this._Options;
                }
            }
            set
            {
                this._Options = value;
            }
        }


        private List<T> GetOptionsFromAPI()
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString(URL_API_LISTs + Service + "/" + ListId);
                var options = JsonConvert.DeserializeObject<CtrlAPIResponse<List<T>>>(response);

                if (typeof(T) == typeof(Usuario))
                {
                    options.Data.ForEach(option =>
                    {
                        var usuario = option as Usuario;
                        option[DescriptionField] = "(" + usuario.Identificacion + ") " + usuario.PNombre + " " + usuario.PApellido;
                    });
                }
                if (typeof(T) == typeof(Empresa_Bus) ||
                    typeof(T) == typeof(Terminal))
                {
                    options.Data.ForEach(option =>
                    {
                        option[DescriptionField] = "(" + option["CEDULA_JUR"] + ") " + option["NOMBRE"];
                    });
                }

                return options.Data;
            } catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex, storeOnly: true);
                return new List<T>();
            }
            
        }

        public string DisplayOptions
        {
            get
            {
                var headers = "";

                if (Placeholder && Multiple == "") headers += $"<option selected='true' value='' disabled>Escoja Una Opcion</option>";
                if (Default && Multiple == "") headers += $"<option value='null'>Ninguno</option>";

                Options.ForEach(option =>
                {
                    headers += $"<option value='{option[IdField]}'>{option[DescriptionField]}</option>";
                });
                return headers;
            }
        }

    }
}