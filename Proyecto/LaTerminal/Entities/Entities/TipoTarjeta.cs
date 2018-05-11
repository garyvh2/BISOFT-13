using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("TIPO_TARJETA")]
    public class TipoTarjeta : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string ID { get; set; }
        [IsEntityProperty]
        public string NOMBRE { get; set; }
        [IsEntityProperty]
        public double BENEFICIO { get; set; }

        public TipoTarjeta()
        {

        }
    }
}
