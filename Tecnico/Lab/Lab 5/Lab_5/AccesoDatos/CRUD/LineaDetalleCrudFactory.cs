using AccesoDatos.DAO;
using AccesoDatos.Mapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.CRUD
{
    public class LineaDetalleCrudFactory : CrudFactory
    {
        LineaDetalleMapper mapper;

        public LineaDetalleCrudFactory() : base()
        {
            mapper = new LineaDetalleMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var lineaDetalle = (LineaDetalle)entity;
            var sqlOperation = mapper.GetCreateStatement(lineaDetalle);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var lineaDetalle = (LineaDetalle)entity;
            var sqlOperation = mapper.GetDeleteStatement(lineaDetalle);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstlineaDetalles = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstlineaDetalles.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstlineaDetalles;
        }

        public List<T> RetrieveAllByPedido<T>(BaseEntity entity)
        {
            var lstlineaDetalles = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByPedidoStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstlineaDetalles.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstlineaDetalles;
        }

        public override void Update(BaseEntity entity)
        {
            var lineaDetalle = (LineaDetalle)entity;
            var sqlOperation = mapper.GetUpdateStatement(lineaDetalle);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
