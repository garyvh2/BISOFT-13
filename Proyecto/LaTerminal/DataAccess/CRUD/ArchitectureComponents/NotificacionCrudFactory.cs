using DataAccess.DAO;
using DataAccess.MAPPER;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes;
using Entities.Entities;
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
    public class NotificacionCrudFactory : CrudFactory<Notificacion, NotificacionMapper>
    {
        // >> Constructor
        public NotificacionCrudFactory() : base()
        {
            base.mapper = new NotificacionMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
    }
}
