using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("USUARIO")]
    public class Usuario : BaseEntity
    {
        // >> Attributes
        [IsEntityProperty, IsIdentity]
        public string Identificacion { get; set; }
        [IsEntityProperty(IsNullable: true)]
        public string Id_Empresa_Bus { get; set; } = null;
        [IsEntityProperty(IsNullable: true)]
        public string Id_Terminal { get; set; } = null;
        [IsEntityProperty]
        public string Id_Rol { get; set; }
        [IsEntityProperty]
        public string Foto { get; set; } = "";
        [IsEntityProperty]
        public string PNombre { get; set; }
        [IsEntityProperty]
        public string SNombre { get; set; } = "";
        [IsEntityProperty]
        public string PApellido { get; set; }
        [IsEntityProperty]
        public string SApellido { get; set; } = "";
        [IsEntityProperty]
        public string Genero { get; set; }
        [IsEntityProperty]
        public DateTime Fecha_Nac { get; set; }
        [IsEntityProperty]
        public string Telefono { get; set; }
        [IsEntityProperty]
        public string Correo { get; set; }
        [IsEntityProperty]
        public string Direccion { get; set; }
        [IsEntityProperty]
        public string Clave { get; set; }
        // >> Flags
        [IsEntityProperty]
        public bool First_Time { get; set; } = true;
        [IsEntityProperty]
        public bool Approved { get; set; } = true;

        // >> Decoracion
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Completo { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Rol_Name { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Empresa_Bus_Name { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Terminal_Name { get; set; } = null;

        
        public string Clave_Actual { get; set; }

        // >> Constructor
        public Usuario ()
        {

        }

    }
}
