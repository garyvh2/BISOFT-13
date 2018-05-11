using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    public class TraduccionPalabra : BaseEntity
    {
        public int Id_Palabra { get; set; }
        public int Id_Traduccion { get; set; }
        public int Orden { get; set; }

        public TraduccionPalabra ()
        {

        }
    }
}
