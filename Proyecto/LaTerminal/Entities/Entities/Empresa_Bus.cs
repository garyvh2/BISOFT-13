using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    [DBTable("EMPRESA_BUS")]
    public class Empresa_Bus : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string CEDULA_JUR { get; set; }
        [IsEntityProperty]
        public string LOGO { get; set; } = "";
        [IsEntityProperty]
        public string CODIGO { get; set; }
        [IsEntityProperty]
        public string NOMBRE { get; set; }
        [IsEntityProperty]
        public string TELEFONO { get; set; }
        [IsEntityProperty]
        public string CORREO { get; set; }
        [IsEntityProperty]
        public string ESTADO { get; set; } = "";

        // Consulta
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string ID_TERMINAL { get; set; }
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string NOMBRE_TERMINAL { get; set; }

        public Empresa_Bus()
        {

        }
    }
}
