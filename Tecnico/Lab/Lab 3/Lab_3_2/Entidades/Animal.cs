using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Animal : BaseEntity
    {
        // Propiedades (Get / Set)
        public int      Id              { get; set; }
        public string   Nombre          { get; set; }
        public string   Categoria       { get; set; }
        public string   Alimento        { get; set; }
        public double   Edad            { get; set; }
        public DateTime FechaNac        { get; set; }
        // Constructores
        public Animal ()
        {
        }
    }
}
