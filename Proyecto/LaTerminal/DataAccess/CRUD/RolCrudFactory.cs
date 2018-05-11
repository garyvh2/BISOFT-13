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
    // >> =====================================================================================
    public class RolCrudFactory : CrudFactory<Rol, RolMapper>
    {
        // >> Constructor
        public RolCrudFactory() : base()
        {
            base.mapper = new RolMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        // >> Asignar permiso a rol
        public void AsignarPermiso(BaseEntity entity)
        {
            var sqlOperation = mapper.GetAsignarPermisoStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Deasignar permiso a rol
        public void DesasignarPermiso (BaseEntity entity)
        {
            var sqlOperation = mapper.GetDesasignarPermisoStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
