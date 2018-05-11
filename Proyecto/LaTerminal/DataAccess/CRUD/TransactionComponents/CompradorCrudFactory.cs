using DataAccess.DAO;
using DataAccess.MAPPER;
using DataAccess.MAPPER.TransactionComponents;
using Entities.Classes;
using Entities.Entities.TransactionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD.TransactionComponents
{
    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class CompradorCrudFactory : CrudFactory<Comprador, CompradorMapper>
    {
        // >> Constructor
        public CompradorCrudFactory() : base()
        {
            base.mapper = new CompradorMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
