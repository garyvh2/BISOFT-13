using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("SANCION")]
    public class Sancion : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Id_Empresa_Bus { get; set; }
        [IsEntityProperty]
        public string Detalle { get; set; }
        [IsEntityProperty]
        public DateTime Fecha { get; set; }
        [IsEntityProperty]
        public double Monto { get; set; }
        [IsEntityProperty]
        public string Tipo { get; set; }
        [IsEntityProperty]
        public string Estado { get; set; } = "ACTIVA";

        public Sancion()
        {

        }
    }
}
