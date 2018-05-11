using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("TARJETA")]
    public class Tarjeta : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string Codigo { get; set; }
        [IsEntityProperty(IsNullable: true)]
        public string Id_Usuario { get; set; }
        [IsEntityProperty]
        public string Id_Terminal { get; set; }
        [IsEntityProperty]
        public string Id_Tipo { get; set; }
        [IsEntityProperty]
        public float Saldo { get; set; }
        [IsEntityProperty]
        public DateTime Fecha_Emision { get; set; }
        [IsEntityProperty]
        public DateTime Fecha_Vencimiento { get; set; }
        [IsEntityProperty]
        public string Estado { get; set; } = "INACTIVA";

        // >> Decoracion
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Terminal { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Tipo { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Estado { get; set; } = null;

        public Tarjeta()
        {

        }
    }
}
