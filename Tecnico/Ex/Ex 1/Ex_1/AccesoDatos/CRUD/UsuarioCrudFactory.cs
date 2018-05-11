using AccesoDatos.DAO;
using AccesoDatos.Mapper;
using Entidades;
using Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.CRUD
{
    public class UsuarioCrudFactory : CrudFactory
    {
        // >> Mapper
        UsuarioMapper mapper;
        // >> Constructor
        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public override void Create(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Create & Retrieve
        public T Create<T>(BaseEntity entity)
        {
            var pedido = (Usuario)entity;
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
        // >> Read
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
        // >> List
        public override List<T> RetrieveAll<T>()
        {
            var lstusuarios = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstusuarios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstusuarios;
        }
        // >> Update
        public override void Update(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetUpdateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Update & Retrieve
        public T Update<T>(BaseEntity entity)
        {
            var pedido = (Usuario)entity;
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
        // >> Delete
        public override void Delete(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetDeleteStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
