using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("PARADAS")]
    public class Parada : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Id_Empresa_Bus { get; set; }
        [IsEntityProperty]
        public string Nombre { get; set; }
        [IsEntityProperty]
        public string Direccion { get; set; }
        [IsEntityProperty]
        public float Lat { get; set; }
        [IsEntityProperty]
        public float Long { get; set; }
        [IsEntityProperty]
        public int Estado { get; set; }

        public Parada ()
        {

        }
    }
}
