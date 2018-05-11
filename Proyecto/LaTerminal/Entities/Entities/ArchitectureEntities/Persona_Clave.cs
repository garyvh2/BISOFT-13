using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("PERSONA_CLAVES")]
    public class Persona_Clave : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Id_Usuario { get; set; }
        [IsEntityProperty]
        public DateTime Fecha { get; set; }
        [IsEntityProperty]
        public string Clave { get; set; }

        public Persona_Clave()
        {

        }
    }
}
