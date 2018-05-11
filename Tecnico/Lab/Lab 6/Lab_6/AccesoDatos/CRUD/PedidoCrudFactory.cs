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
    public class PedidoCrudFactory : CrudFactory
    {
        PedidoMapper mapper;

        public PedidoCrudFactory() : base()
        {
            mapper = new PedidoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var pedido = (Pedido)entity;
            var sqlOperation = mapper.GetCreateStatement(pedido);
            dao.ExecuteProcedure(sqlOperation);

        }

        public T Create<T>(BaseEntity entity)
        {
            var pedido = (Pedido)entity;
            var sqlOperation = mapper.GetCreateStatement(pedido);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public override void Delete(BaseEntity entity)
        {
            var pedido = (Pedido)entity;
            var sqlOperation = mapper.GetDeleteStatement(pedido);
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
            var lstpedidos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstpedidos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstpedidos;
        }

        public override void Update(BaseEntity entity)
        {
            var pedido = (Pedido)entity;
            var sqlOperation = mapper.GetUpdateStatement(pedido);
            dao.ExecuteProcedure(sqlOperation);
        }

        public T Update<T>(BaseEntity entity)
        {
            var pedido = (Pedido)entity;
            var sqlOperation = mapper.GetUpdateStatement(pedido);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
    }
}
