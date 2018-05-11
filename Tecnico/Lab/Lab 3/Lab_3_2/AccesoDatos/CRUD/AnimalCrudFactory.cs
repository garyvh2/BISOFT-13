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
    public class AnimalCrudFactory : CrudFactory
    {
        AnimalMapper mapper;

        public AnimalCrudFactory() : base()
        {
            mapper = new AnimalMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetCreateStatement(animal);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetDeleteStatement(animal);
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
            var lstanimals = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstanimals.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstanimals;
        }
        public List<T> RetrieveAllByCategoria<T>(BaseEntity entity)
        {
            var lstanimals = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByCategoriaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstanimals.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstanimals;
        }
        public List<T> RetrieveAllByNombre<T>(BaseEntity entity)
        {
            var lstanimals = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByNombreStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstanimals.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstanimals;
        }

        public override void Update(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetUpdateStatement(animal);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
