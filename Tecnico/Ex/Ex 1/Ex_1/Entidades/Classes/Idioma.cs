using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    public class Idioma : BaseEntity
    {
        // >> Propiedades
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Popularidad { get; set; }

        // >> Constructor
        public Idioma () {}

        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre;
        }
    }
}
