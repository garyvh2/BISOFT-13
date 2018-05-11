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
    public class ParadaCrudFactory : CrudFactory<Parada, ParadaMapper>
    {
        // >> Constructor
        public ParadaCrudFactory() : base()
        {
            base.mapper = new ParadaMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
