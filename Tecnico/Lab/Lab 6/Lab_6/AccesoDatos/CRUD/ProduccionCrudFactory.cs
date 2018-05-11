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
    public class ProduccionCrudFactory : CrudFactory
    {
        ProduccionMapper mapper;

        public ProduccionCrudFactory() : base()
        {
            mapper = new ProduccionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var produccion = (Produccion)entity;
            var sqlOperation = mapper.GetCreateStatement(produccion);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Create & Retrieve
        public T Create<T>(BaseEntity entity)
        {
            var pedido = (Produccion)entity;
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
            var produccion = (Produccion)entity;
            var sqlOperation = mapper.GetDeleteStatement(produccion);
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
            var lstproduccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstproduccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstproduccions;
        }

        public List<T> RetrieveAllByAnimal<T>(BaseEntity entity)
        {
            var lstproduccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByAnimalStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstproduccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstproduccions;
        }
        public List<T> RetrieveAllByRango<T>(BaseEntity entity)
        {
            var lstproduccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByRangoStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstproduccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstproduccions;
        }
        public List<T> RetrieveAllByRangoCategoria<T>(BaseEntity entity)
        {
            var lstproduccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByRangoCategoriaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstproduccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstproduccions;
        }
        public override void Update(BaseEntity entity)
        {
            var produccion = (Produccion)entity;
            var sqlOperation = mapper.GetUpdateStatement(produccion);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Update & Retrieve
        public T Update<T>(BaseEntity entity)
        {
            var pedido = (Produccion)entity;
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
