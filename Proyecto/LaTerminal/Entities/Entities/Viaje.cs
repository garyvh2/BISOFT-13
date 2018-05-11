using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("VIAJE")]
    public class Viaje : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public int Id_Horario { get; set; }
        [IsEntityProperty]
        public DateTime Salida { get; set; }
        [IsEntityProperty]
        public DateTime Llegada { get; set; }
        [IsEntityProperty]
        public float Distancia { get; set; }
        [IsEntityProperty]
        public DateTime Tiempo { get; set; }
        [IsEntityProperty]
        public int Estado { get; set; }

        public Viaje ()
        {

        }
    }
}
