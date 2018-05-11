using AccesoDatos.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Planeta
    {
        // Stributos
        public int _Id { get; set; }
        public int _IdSistema { get; set; }
        private Sistema _Sistema;
        public string _Nombre { get; set; }
        public int _SunDistance { get; set; }
        public DateTime _Fecha { get; set; }

        public Sistema Sistema
        {
            get
            {
                SistemaMapper SistemaM = new SistemaMapper();
                return SistemaM.findById(this._IdSistema);
            }
        }
        // Constructores
        public Planeta() { }
        public Planeta(int Id, int IdSistema, string Nombre, int SunDistance, DateTime Fecha)
        {
            this._Id = Id;
            this._IdSistema = IdSistema;
            this._Nombre = Nombre;
            this._SunDistance = SunDistance;
            this._Fecha = Fecha;
        }
    }
}
