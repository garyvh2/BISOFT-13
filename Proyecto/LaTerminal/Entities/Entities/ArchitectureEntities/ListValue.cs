using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.ArchitectureEntities
{
    [DBTable("LISTA_VALOR")]
    public class ListValue : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string Id_Lista { get; set; } = "";
        [IsEntityProperty, IsIdentity]
        public string Valor { get; set; } = "";
        [IsEntityProperty]
        public string Descripcion { get; set; }

        public ListValue()
        {

        }
    }
}
