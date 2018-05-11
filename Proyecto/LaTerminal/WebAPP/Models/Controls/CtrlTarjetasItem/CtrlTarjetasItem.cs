using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls
{
    public class CtrlTarjetasItem : CtrlBaseModel
    {
        public string Codigo { get; set; }
        public string Id_Tipo { get; set; }
        public float Saldo { get; set; }

        private string _Estado;
        public string Estado
        {
            get
            {
                return UpperFirst(this._Estado.ToLower() ?? "");
            }
            set
            {
                this._Estado = value;
            }
        }

        public string Icono_Estado
        {
            get
            {
                var Icon = "fa-ellipsis-h";
                switch (this._Estado)
                {
                    case "VENCIDA":
                        Icon = "fa-hourglass-end";
                        break;
                    case "INVALIDA":
                        Icon = "fa-ban";
                        break;
                    case "EXTRAVIADA":
                        Icon = "fa-question-circle";
                        break;
                    case "AVERIADA":
                        Icon = "fa-wrench";
                        break;
                    case "INACTIVA":
                        Icon = "fa-pause-circle";
                        break;
                    case "ACTIVA":
                        Icon = "fa-check-circle";
                        break;
                }
                return Icon;
            }
        }
        public string Color_Estado
        {
            get
            {
                var Color = "3E3E3E";
                switch (this._Estado)
                {
                    case "VENCIDA":
                        Color = "FF9B48";
                        break;
                    case "INVALIDA":
                        Color = "FF6B67";
                        break;
                    case "EXTRAVIADA":
                        Color = "C5C5C5";
                        break;
                    case "AVERIADA":
                        Color = "EFB239";
                        break;
                    case "INACTIVA":
                        Color = "667BD2";
                        break;
                    case "ACTIVA":
                        Color = "8CE362";
                        break;
                }
                return Color;
            }
        }
        public string Activar
        {
            get
            {
                if (this._Estado == "INACTIVA")
                    return $"<a id='entry_activar' onclick='ActivarTarjeta(\"{this.Codigo}\")' class='dropdown-item' href='#'>Activar</a>";

                return "";
            }
        }

        public string Icono_Tipo
        {
            get
            {
                var Icon = "fa-ellipsis-h";
                switch (this.Id_Tipo)
                {
                    case "ESPECIAL":
                        Icon = "fa-wheelchair";
                        break;
                    case "TURISTA":
                        Icon = "fa-camera";
                        break;
                    case "ESTUDIANTE":
                        Icon = "fa-graduation-cap";
                        break;
                    case "BASICO":
                        Icon = "fa-user";
                        break;
                }
                return Icon;
            }
        }
        public string Icono_Color
        {
            get
            {
                var Color = "3E3E3E";
                switch (this._Estado)
                {
                    case "VENCIDA":
                        Color = "D06105";
                        break;
                    case "INVALIDA":
                        Color = "D21F1A";
                        break;
                    case "EXTRAVIADA":
                        Color = "191F90";
                        break;
                    case "AVERIADA":
                        Color = "A57005";
                        break;
                    case "INACTIVA":
                        Color = "241385";
                        break;
                    case "ACTIVA":
                        Color = "246E00";
                        break;
                }
                return Color;
            }
        }

        private DateTime _Fecha_Emision;
        public string Fecha_Emision
        {
            get
            {
                return _Fecha_Emision.ToString("yyyy MM dd - HH:mm:ss");
            }
            set
            {
                this._Fecha_Emision = DateTime.Parse(value);
            }

        }

        private DateTime _Fecha_Vencimiento;
        public string Fecha_Vencimiento
        {
            get
            {
                return _Fecha_Vencimiento.ToString("yyyy MM dd - HH:mm:ss");
            }
            set
            {
                this._Fecha_Vencimiento = DateTime.Parse(value);
            }

        }

        // >> Decoracion
        public string Nombre_Terminal { get; set; } = null;
        public string Nombre_Tipo { get; set; } = null;
        public string Nombre_Estado { get; set; } = null;

        public CtrlTarjetasItem()
        {

        }
    }
}