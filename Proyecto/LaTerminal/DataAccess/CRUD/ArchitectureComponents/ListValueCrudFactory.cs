using DataAccess.DAO;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes;
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
    public class ListValueCrudFactory : CrudFactory<ListValue, ListValueMapper>
    {
        public ListValueCrudFactory()
        {
            base.mapper = new ListValueMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<

        // >> Metodo de extraccion generalizada de objetos
        public List<ListValue> RetrieveAllByIdLista(BaseEntity entity)
        {
            var lstidiomas = new List<ListValue>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByIdListaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((ListValue)Convert.ChangeType(c, typeof(ListValue)));
                }
            }

            return lstidiomas;
        }
    }
}
