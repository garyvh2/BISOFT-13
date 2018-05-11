using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{

    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class ViajesTarjetasCrudFactory : CrudFactory<Viajes_Tarjetas, Viajes_TarjetasMapper>
    {
        // >> Constructor
        public ViajesTarjetasCrudFactory() : base()
        {
            base.mapper = new Viajes_TarjetasMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
