using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("VIAJES_TARJETAS")]
    public class Viajes_Tarjetas : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public int Id { get; set; }
        [IsEntityProperty]
        public int Id_Viaje { get; set; }
        [IsEntityProperty]
        public string Id_Tarjeta { get; set; }
        [IsEntityProperty]
        public float Pasaje { get; set; }
        [IsEntityProperty]
        public DateTime Fecha { get; set; }
        [IsEntityProperty]
        public int Estado { get; set; }

        public Viajes_Tarjetas ()
        {

        }
    }
}
