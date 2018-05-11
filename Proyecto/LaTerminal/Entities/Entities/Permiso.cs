using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("PERMISO")]
    public class Permiso : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Nombre { get; set; }
        [IsEntityProperty]
        public string Icono { get; set; }
        [IsEntityProperty]
        public string Accion { get; set; }
        [IsEntityProperty]
        public int Orden { get; set; }

        // Consulta
        public string Id_Rol { get; set; }

        public Permiso ()
        {

        }
    }
}
