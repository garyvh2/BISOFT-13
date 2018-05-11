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
    public class PalabraCrudFactory : CrudFactory
    {
        // >> Mapper
        PalabraMapper mapper;
        // >> Constructor
        public PalabraCrudFactory() : base()
        {
            mapper = new PalabraMapper();
            dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public override void Create(BaseEntity entity)
        {
            var palabra = (Palabra)entity;
            var sqlOperation = mapper.GetCreateStatement(palabra);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Create & Retrieve
        public T Create<T>(BaseEntity entity)
        {
            var pedido = (Palabra)entity;
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
        // >> Read by Palabra
        public T RetrieveByPalabra<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByPalabraStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        // >> Read by Familia & Idioma
        public T RetrieveByFamiliaAndIdioma<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByFamiliaAndIdiomaStatement(entity));
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
            var lstpalabras = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstpalabras.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstpalabras;
        }
        // >> List by idioma
        public List<T> RetrieveAllByIdioma<T>(BaseEntity entity)
        {
            var lstpalabras = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByIdiomaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstpalabras.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstpalabras;
        }
        // >> Update
        public override void Update(BaseEntity entity)
        {
            var palabra = (Palabra)entity;
            var sqlOperation = mapper.GetUpdateStatement(palabra);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Update & Retrieve
        public T Update<T>(BaseEntity entity)
        {
            var pedido = (Palabra)entity;
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
            var palabra = (Palabra)entity;
            var sqlOperation = mapper.GetDeleteStatement(palabra);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Top 100
        public List<T> RetrieveTop100<T>()
        {
            var lstpalabras = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveTop100Statement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstpalabras.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstpalabras;
        }
        // >> Top 10 Dia
        public List<T> RetrieveTop10Dia<T>(BaseEntity entity)
        {
            var lstpalabras = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveTop10DiaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstpalabras.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstpalabras;
        }
    }
}
