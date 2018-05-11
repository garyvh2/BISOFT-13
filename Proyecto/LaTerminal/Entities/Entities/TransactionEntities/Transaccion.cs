using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.TransactionEntities
{
    [DBTable("TRANSACCION")]
    public class Transaccion :  BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id                       { get; set; }
        [IsEntityProperty(IsNullable: true)]
        public string Id_Terminal           { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public string Id_Usuario            { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public string Id_Empresa_Bus        { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public string Id_Tarjeta            { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public int? Id_Uso_Tarjeta          { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public int? Id_Sancion              { get; set; } = null;
        [IsEntityProperty]
        public string Tipo                  { get; set; }
        [IsEntityProperty]
        public float Monto                  { get; set; }
        [IsEntityProperty]
        public DateTime Fecha               { get; set; }

        // >> Decoracion
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Completo { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Empresa_Bus_Name { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Terminal_Name { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Tipo_Name { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Detalle { get; set; } = null;

        public Transaccion ()
        {

        }
    }
}
