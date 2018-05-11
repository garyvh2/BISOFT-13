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
    // >> CrudFactory <<
    // >> Es la clase abstracta poseedora de los metodos por defecto en todo CRUD del sistema
    // >> ===================================================================================== <<
    public abstract class CrudFactory<T, M> where M : EntityMapper, ISqlStaments, IObjectMapper where T : BaseEntity
    {
        protected SqlDao dao;
        protected M mapper;
        // >>=========================================================================<<
        //                         >> Operaciones CRUD Basicas <<
        // >>=========================================================================<<
        // >> Metodo de creacion de objetos
        public T Create(BaseEntity entity)
        {
            var sqlOperation = mapper.GetCreateStatement(entity);

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
        // >> Metodo de extraccion de datos por ID
        public T Retrieve(BaseEntity entity)
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
        // >> Metodo de extraccion generalizada de objetos
        public List<T> RetrieveAll()
        {
            var lstidiomas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstidiomas;
        }
        // >> Metodo de actualizacion de objetos
        public T Update(BaseEntity entity)
        {
            var sqlOperation = mapper.GetUpdateStatement(entity);

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
        // >> Metodo de eliminacion de objeto
        public void Delete(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

    }
}
