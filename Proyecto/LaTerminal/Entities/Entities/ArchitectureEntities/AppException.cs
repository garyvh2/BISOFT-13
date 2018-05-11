using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes.ArquitectureEntities
{
    [DBTable("EXCEPCION")]
    public class AppException : BaseEntity
    {
        // >> Properties
        [IsEntityProperty, IsIdentity(false)]
        public int Id               { get; set; }
        [IsEntityProperty]
        public int Codigo           { get; set; }
        [IsEntityProperty]
        public string Mensaje       { get; set; }
        [IsEntityProperty]
        public string Stacktrace    { get; set; }
        [IsEntityProperty]
        public DateTime Fecha       { get; set; }

        // >> Constructores 
    }
}
