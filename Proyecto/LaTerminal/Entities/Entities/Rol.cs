using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("ROL")]
    public class Rol : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string Id { get; set; }
        [IsEntityProperty]
        public string Nombre { get; set; }
        [IsEntityProperty]
        public string Descripcion { get; set; }

        public List<Permiso> Permisos { get; set; }

        public Rol ()
        {

        }
    }
}
