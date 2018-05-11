using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("Notificacion")]
    public class Notificacion : BaseEntity
    {
        // >> Attributes
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Remitente { get; set; }
        [IsEntityProperty]
        public string Destinatario { get; set; }
        [IsEntityProperty]
        public string Mensaje { get; set; }
        [IsEntityProperty]
        public DateTime Fecha { get; set; }
        [IsEntityProperty]
        public string Tipo { get; set; }

        public Notificacion ()
        {

        }
    }
}
