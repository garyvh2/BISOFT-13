using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPP.Models.Controls.CtrlNavigation
{
    public class CtrlNavigation : CtrlBaseModel
    {
        public Usuario Current_User { get; set; }

        public CtrlNavigation()
        {
        }
        private string URL_API = ConfigurationManager.AppSettings["API_BASE_URL"] + "permiso/rol/";
        private List<Permiso> _Options;


        public List<Permiso> Options
        {
            get
            {
                return GetOptionsFromAPI();
            }
            set
            {
                this._Options = value;
            }
        }

        public string UserName
        {
            get
            {
                var full_name =
                    (this.Current_User.PNombre ?? "") + " " +
                    (this.Current_User.PApellido ?? "") + " " +
                    (this.Current_User.SApellido ?? "");
                return full_name;
            }
        }

        public string UserPhoto
        {
            get
            {
                if (this.Current_User.Foto == "" || this.Current_User.Foto == null) return "/Content/Imgs/profile_thumbnail.png";

                return ConfigurationManager.AppSettings["API_BASE_URL"] + "image/user/" + this.Current_User.Identificacion;

            }
        }


        private List<Permiso> GetOptionsFromAPI()
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString(URL_API + Current_User.Id_Rol);
                var options = JsonConvert.DeserializeObject<CtrlAPIResponse<List<Permiso>>>(response);
                return options.Data;
            }
            catch
            {
                return new List<Permiso>();
            }

        }

        public string DisplayOptions
        {
            get
            {
                var items = "";
                Options
                    .OrderBy(option => option.Orden > 0 ? option.Orden : 1000)
                    .ToList()
                    .ForEach(option =>
                {
                    var route = option.Accion.Split('/');
                    items +=
                    $@"<a id=""nav-item-{option.Id}"" onclick=""ltl.go(['{string.Join("','", route)}'])"" href='#'>
                         <li class='drawing-list-item'>
                            <span class='drawing-icon'>
                                <i class='{option.Icono}'></i>
                            </span>
                            <span class='drawing-text'>
                                <p>{option.Nombre}</p>
                            </span>
                        </li>
                    </a>";
                });
                return items;
            }
        }
    }
}