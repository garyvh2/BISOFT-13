using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    [DBTable("HORARIO")]
    public class Horarios : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public string Id { get; set; }
        [IsEntityProperty]
        public string Id_Ruta { get; set; }
        [IsEntityProperty]
        public string Id_Bus { get; set; }
        [IsEntityProperty]
        public string Salida { get; set; }
        [IsEntityProperty]
        public string Llegada { get; set; }
        [IsEntityProperty]
        public string Estado { get; set; }
        [IsEntityProperty]
        public string NUMERO_RUTA { get; set; }

        public Horarios()
        {

        }
    }
}
