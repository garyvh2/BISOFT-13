using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    public class Palabra : BaseEntity
    {
        // >> Propiedades
        public int Id { get; set; }
        public Idioma Idioma { get; set; }
        public int Id_Idioma { get; set; }
        public int Id_Traductor { get; set; }
        public string Familia { get; set; }
        public string _Palabra { get; set; }
        public DateTime Fecha { get; set; }
        public int Popularidad { get; set; }

        // >> Propiedades de consulta
        public int DiaSemana { get; set; }

        // >> Constructor
        public Palabra() { }
    }
}
