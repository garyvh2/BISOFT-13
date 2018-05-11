using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("RUTA")]
    public class Ruta : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string Numero_Ruta { get; set; }
        [IsEntityProperty]
        public string Id_Empresa_Bus { get; set; }
        [IsEntityProperty]
        public string Descripcion { get; set; }
        [IsEntityProperty]
        public float Destino_Lat { get; set; }
        [IsEntityProperty]
        public float Destino_Long { get; set; }
        [IsEntityProperty]
        public float Tarifa_Por_Kilometro { get; set; }
        [IsEntityProperty]
        public float Tarifa { get; set; }
        [IsEntityProperty]
        public float Distancia { get; set; }
        [IsEntityProperty]
        public int Estado { get; set; }
        

        public Ruta ()
        {

        }
    }
}
