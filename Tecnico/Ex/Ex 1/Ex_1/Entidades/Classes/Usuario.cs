using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    public class Usuario : BaseEntity
    {
        // >> Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // >> Constructor
        public Usuario() { }
    }
}
