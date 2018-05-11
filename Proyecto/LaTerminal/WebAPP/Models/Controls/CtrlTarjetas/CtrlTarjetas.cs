using Cliente.Lib.Requester;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPP.Models.Controls.CtrlTarjetas
{
    public class CtrlTarjetas : CtrlBaseModel
    {

        private string URL_API = ConfigurationManager.AppSettings["API_BASE_URL"];

        // =========================================== Attributes ===========================================
        public Usuario Current_User { get; set; }
        private List<CtrlTarjetasItem> _Entries = new List<CtrlTarjetasItem>();
        public List<CtrlTarjetasItem> Entries
        {
            get
            {
                var API_Entries = GetOptionsFromAPI();

                API_Entries.ForEach(Entry =>
                {
                    var CtrlEntry = new CtrlTarjetasItem()
                    {
                        Id                  = Entry.Codigo,
                        Codigo              = Entry.Codigo,
                        Id_Tipo             = Entry.Id_Tipo,
                        Saldo               = Entry.Saldo,
                        Estado              = Entry.Estado,
                        Fecha_Emision       = Entry.Fecha_Emision.ToString(),
                        Fecha_Vencimiento   = Entry.Fecha_Vencimiento.ToString(),
                        Nombre_Terminal     = Entry.Nombre_Terminal,
                        Nombre_Tipo         = Entry.Nombre_Tipo,
                        Nombre_Estado       = Entry.Nombre_Estado
                    };

                    _Entries.Add(CtrlEntry);
                });

                return _Entries;
            }
            set
            {
                this._Entries = value;
            }
        }


        public string DisplayOptions
        {
            get
            {
                var HTMLEntries = "";
                _Entries.ForEach(_Entry =>
                {
                    HTMLEntries += _Entry.GetHtml();
                });

                if (HTMLEntries == "")
                {
                    HTMLEntries += "<div class='title'><h1>No hay tarjetas</h1></div>";
                }

                return HTMLEntries;
            }
        }

        // =========================================== Constructor ===========================================
        public CtrlTarjetas()
        {
        }


        // =========================================== Methods ===========================================
        // Get Data From API
        private List<Tarjeta> GetOptionsFromAPI()
        {
            try
            {
                var Tarjetas = new List<Tarjeta>();
                RequestReponse<List<Tarjeta>> response = new RequestReponse<List<Tarjeta>>();
                // >> Request
                var req = new RequestParams()
                {
                    Url = URL_API + "tarjeta/usuario",
                    Body = new Tarjeta()
                    {
                        Id_Usuario = Current_User.Identificacion
                    }
                };
                new Request(req).Run<List<Tarjeta>>(data =>
                {
                    Tarjetas = data.Data;
                });


                return Tarjetas;
            }
            catch
            {
                return new List<Tarjeta>();
            }

        }
        
    }
}