using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Sistema
    {
        // Stributos
        public int _Id { get; set; }
        public string _Nombre { get; set; }
        public DateTime _Fecha { get; set; }
        // Constructores
        public Sistema() { }
        public Sistema(int Id, string Nombre, DateTime Fecha)
        {
            this._Id = Id;
            this._Nombre = Nombre;
            this._Fecha = Fecha;
        }
    }
}
