using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.TransactionEntities
{
    [DBTable("COMPRADOR")]
    public class Comprador : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public int Id_Factura { get; set; }
        [IsEntityProperty]
        public string Nombre_Completo { get; set; } = "";
        [IsEntityProperty]
        public string Telefono { get; set; } = "";
        [IsEntityProperty]
        public string Correo { get; set; } = "";

        public Comprador()
        {

        }

    }
}
