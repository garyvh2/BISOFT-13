using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.ArchitectureEntities
{
    [DBTable("CONFIGURACION")]
    public class ConfigurationItem : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string Codigo { get; set; }
        [IsEntityProperty]
        public string Valor { get; set; }
        [IsEntityProperty]
        public string Descripcion { get; set; }


        public ConfigurationItem ()
        {

        }
    }
}
