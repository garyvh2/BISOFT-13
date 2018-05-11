using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class RequisitosCrudFactory : CrudFactory<Requisitos, RequisitosMapper>
    {

        public RequisitosCrudFactory() : base()
        {
            base.mapper = new RequisitosMapper();
            base.dao = SqlDao.GetInstance();
        }

        public List<Requisitos> ListarRequisito()
        {
            var lstRequisito = new List<Requisitos>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.ListarRequisito());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstRequisito.Add((Requisitos)Convert.ChangeType(c, typeof(Requisitos)));
                }
            }

            return lstRequisito;
        }
    }
}
