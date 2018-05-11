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
    public class Empresa_BusCrudFactory : CrudFactory<Empresa_Bus, Empresa_BusMapper>
    {
        // >> Constructor
        public Empresa_BusCrudFactory() : base()
        {
            base.mapper = new Empresa_BusMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        // >> Asignar permiso a rol
        public void AsignarATerminal(BaseEntity entity)
        {
            var sqlOperation = mapper.GetAsignarATerminalStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Deasignar permiso a rol
        public void DesasignarDeTerminal(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDesasignarDeTerminalStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<Empresa_Bus> RetrieveAllGroupedByTerminal()
        {
            var lstidiomas = new List<Empresa_Bus>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllGroupedByTerminal());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Empresa_Bus)Convert.ChangeType(c, typeof(Empresa_Bus)));
                }
            }

            return lstidiomas;
        }
    }
}
