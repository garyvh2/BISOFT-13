using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.TransactionEntities
{
    [DBTable("LINEA_DETALLE")]
    public class Linea_Detalle : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int  Id { get; set; }
        [IsEntityProperty]
        public int Id_Factura { get; set; }
        [IsEntityProperty]
        public string Nombre { get; set; } = "";
        [IsEntityProperty]
        public float Cantidad { get; set; }
        [IsEntityProperty]
        public float Valor_Unitario { get; set; }

        public Linea_Detalle ()
        {

        }

    }
}
