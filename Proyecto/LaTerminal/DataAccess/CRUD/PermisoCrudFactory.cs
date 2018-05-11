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
    public class PermisoCrudFactory : CrudFactory<Permiso, PermisoMapper>
    {
        // >> Constructor
        public PermisoCrudFactory() : base()
        {
            base.mapper = new PermisoMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        // >> Permisos por rol
        public List<Permiso> RetrieveAllByRol(BaseEntity entity)
        {
            var lstidiomas = new List<Permiso>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByRolStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Permiso)Convert.ChangeType(c, typeof(Permiso)));
                }
            }

            return lstidiomas;
        }
    }
}
