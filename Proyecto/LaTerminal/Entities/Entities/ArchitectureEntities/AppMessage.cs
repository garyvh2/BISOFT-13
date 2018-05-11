using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes.ArquitectureEntities
{
    [DBTable("MENSAJE")]
    public class AppMessage : BaseEntity
    {
        // >> Propiedades
        [IsEntityProperty, IsIdentity]
        public int Id           { get; set; }
        [IsEntityProperty]
        public string Mensaje   { get; set; }

        // >> Constructores
    }
}
