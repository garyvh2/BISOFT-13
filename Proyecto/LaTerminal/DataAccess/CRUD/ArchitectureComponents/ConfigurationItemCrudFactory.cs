using DataAccess.DAO;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD.ArchitectureComponents
{
    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class ConfigurationItemCrudFactory : CrudFactory<ConfigurationItem, ConfigurationItemMapper>
    {
        public ConfigurationItemCrudFactory()
        {
            base.mapper = new ConfigurationItemMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
