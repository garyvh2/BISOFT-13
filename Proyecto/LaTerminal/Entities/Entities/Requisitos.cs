using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("REQUISITO")]
    public class Requisitos : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public int ID { get; set; }
        [IsEntityProperty]
        public String NOMBRE { get; set; }

        public Requisitos()
        {

        }
    }
}
