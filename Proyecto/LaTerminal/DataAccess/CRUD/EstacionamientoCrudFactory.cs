using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Classes;
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
    public class EstacionamientoCrudFactory : CrudFactory<Estacionamiento, EstacionamientoMapper>
    {
        // >> Constructor
        public EstacionamientoCrudFactory() : base()
        {
            base.mapper = new EstacionamientoMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
