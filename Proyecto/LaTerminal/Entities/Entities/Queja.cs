using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("QUEJA")]
    public class Queja : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int ID { get; set; }
        [IsEntityProperty(IsNullable: true)]
        public int? ID_VIAJE { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public int? ID_ESTACIONAMIENTO { get; set; } = null;
        [IsEntityProperty]
        public string ID_USUARIO { get; set; }
        [IsEntityProperty]
        public String DETALLE { get; set; }
        [IsEntityProperty]
        public int ESTADO { get; set; } = 1; // Por que Int??

        public Queja()
        {

        }

    }
}
