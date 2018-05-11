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
    public class RequisitoBusCrudFactory : CrudFactory<RequisitoBus, RequisitoBusMapper>
    {
        public RequisitoBusCrudFactory() : base()
        {
            base.mapper = new RequisitoBusMapper();
            base.dao = SqlDao.GetInstance();
        }

        public RequisitoBus modificarRequisito(BaseEntity entity)
        {
            var requisitoBus = (RequisitoBus)entity;
            var sqlOperation = mapper.modificarEstadoRequisito(requisitoBus);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (RequisitoBus)Convert.ChangeType(objs, typeof(RequisitoBus));
            }
            return default(RequisitoBus);
        }

        public List<RequisitoBus> Listar()
        {
            var lstidiomas = new List<RequisitoBus>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.listar());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((RequisitoBus)Convert.ChangeType(c, typeof(RequisitoBus)));
                }
            }

            return lstidiomas;
        }

        public void eliminar(BaseEntity entity)
        {
            var sqlOperation = mapper.ELIMINAR(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
