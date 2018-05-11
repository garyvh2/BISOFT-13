using Cliente.Lib.Requester;
using Entities.Classes;
using Entities.Entities;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace WebAPP.Models.Controls.CtrlSelectSearch
{
    public class CtrlSelectSearch<T> : CtrlBaseModel where T : BaseEntity
    {
        public CtrlSelectSearch()
        {
            Name = "CtrlSelectSearch";
        }

        public string Title { get; set; }
        public string ListId { get; set; }
        public string Disabled { get; set; } = "";
        public string Service { get; set; } = "list";
        public string IdField { get; set; } = "Valor";
        public string DescriptionField { get; set; } = "Descripcion";
        public string Create { get; set; } = "";
        public Usuario Current_User { get; set; } = null;
        public string Method { get; set; } = "GET";
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

        
        public string DisplayOptions
        {
            get
            {
                var headers = "";
                
                Options.ForEach(option =>
                {
                    headers += $"<option value='{option[IdField]}'>{option[DescriptionField]}</option>";
                });
                return headers;
            }
        }


        // =========================================== Methods ===========================================
        // Get Data From API
        private List<T> GetOptionsFromAPI()
        {
            try
            {
                var API_METHOD = HttpMethod.Get;
                switch (Method.ToUpper())
                {
                    case "GET":
                        API_METHOD = HttpMethod.Get;
                        break;
                    case "POST":
                        API_METHOD = HttpMethod.Post;
                        break;
                    default:
                        API_METHOD = HttpMethod.Get;
                        break;
                }


                var Data = new List<T>();
                RequestReponse<List<Tarjeta>> response = new RequestReponse<List<Tarjeta>>();
                // >> Request
                var req = new RequestParams()
                {
                    Url = URL_API_LISTs + Service + "/" + ListId,
                    Body = Current_User,
                    Method = API_METHOD
                };
                new Request(req).Run<List<T>>(data =>
                {
                    Data = data.Data;
                });
                

                if (typeof(T) == typeof(Usuario))
                {
                    Data.ForEach(option =>
                    {
                        var usuario = option as Usuario;
                        option[DescriptionField] = "(" + usuario.Identificacion + ") " + usuario.PNombre + " " + usuario.PApellido;
                    });
                }
                if (typeof(T) == typeof(Empresa_Bus) ||
                    typeof(T) == typeof(Terminal))
                {
                    Data.ForEach(option =>
                    {
                        option[DescriptionField] = "(" + option["CEDULA_JUR"] + ") " + option["NOMBRE"];
                    });
                }

                return Data;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex, storeOnly: true);
                return new List<T>();
            }



        }
    }
}