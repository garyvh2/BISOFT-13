using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    [DBTable("ESTACIONAMIENTO")]
    public class Estacionamiento : BaseEntity
    {
        [IsEntityProperty, IsIdentity(false)]
        public int Id { get; set; }
        [IsEntityProperty]
        public string Id_Terminal { get; set; }
        [IsEntityProperty]
        public string Tipo { get; set; }
        [IsEntityProperty]
        public string Numero { get; set; }
        [IsEntityProperty]
        public string Estado { get; set; } = "";

        public Estacionamiento()
        {

        }
    }
}
