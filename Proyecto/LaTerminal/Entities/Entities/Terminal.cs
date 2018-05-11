using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("TERMINAL")]
    public class Terminal : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public string CEDULA_JUR { get; set; }
        [IsEntityProperty]
        public string NOMBRE { get; set; }
        [IsEntityProperty]
        public string DIRECCION { get; set; }
        [IsEntityProperty]
        public double LAT { get; set; }
        [IsEntityProperty]
        public double LONG { get; set; }
        [IsEntityProperty]
        public string TELEFONO { get; set; }
        [IsEntityProperty]
        public string CORREO { get; set; }
        [IsEntityProperty]
        public int ESTADO { get; set; } = 1;


        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Id_Usuario { get; set; } = null;
        [IsEntityProperty(IsNullable: true, OnlyRetrieve: true)]
        public string Nombre_Encargado { get; set; } = null;
        

        public Terminal()
        {

        }
    }
}
