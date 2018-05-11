using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [DBTable("BUS")]
    public class Bus : BaseEntity
    {
        [IsEntityProperty, IsIdentity]
        public String NUMERO_PLACA { get; set; }
        [IsEntityProperty]
        public String ID_EMPRESA_BUS { get; set; }
        [IsEntityProperty]
        public String ID_CHOFER { get; set; }
        [IsEntityProperty]
        public String NUMERO_UNIDAD { get; set; }
        [IsEntityProperty]
        public String MARCA { get; set; }
        [IsEntityProperty]
        public String MODELO { get; set; }
        [IsEntityProperty]
        public int CAPACIDAD { get; set; }
        [IsEntityProperty]
        public int ESPACIOS_DISCAPACITADOS { get; set; }
        [IsEntityProperty]
        public int ESTADO { get; set; } = 1;

        public Bus()
        {

        }

    }
}
