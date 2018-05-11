using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("REQUISITO_BUS")]
    public class RequisitoBus : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public int ID_REQUISITO_BUS { get; set; }
        [IsEntityProperty]
        public String ID_BUS { get; set; }
        [IsEntityProperty]
        public int ID_REQUISITO { get; set; }
        [IsEntityProperty]
        public String ESTADO { get; set; }
        [IsEntityProperty]
        public String REQUISITO { get; set; }

        public RequisitoBus()
        {

        }
    }
}
