using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    public class Traduccion : BaseEntity
    {
        // >> Propiedades
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public Idioma Original { get; set; }
        public int Idioma_Original { get; set; }
        public Idioma Destino { get; set; }
        public int Idioma_Destino { get; set; }
        public string Frase_Original { get; set; }
        public string Frase_Traducida { get; set; }
        public int Popularidad_Total { get; set; }
        public DateTime Fecha { get; set; }

        // >> Propiedades de consulta
        public int Id_Idioma { get; set; }
        public int Id_Traduccion { get; set; }

        // >> Constructor
        public Traduccion() { }
    }
}
