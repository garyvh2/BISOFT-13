using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.TransactionEntities
{
    [DBTable("FACTURA")]
    public class Factura : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public int Id_Transaccion { get; set; }
        [IsEntityProperty]
        public DateTime Fecha { get; set; }
        [IsEntityProperty]
        public string Vendedor { get; set; }
        [IsEntityProperty]
        public string Detalle { get; set; }
        [IsEntityProperty]
        public float Iva { get; set; }
        [IsEntityProperty]
        public float Subtotal { get; set; }
        [IsEntityProperty]
        public float Total { get; set; }

        public Factura ()
        {

        }

    }
}
