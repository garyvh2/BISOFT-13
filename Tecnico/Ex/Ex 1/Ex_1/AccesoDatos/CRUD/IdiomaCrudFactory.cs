﻿using AccesoDatos.DAO;
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
    public class IdiomaCrudFactory : CrudFactory
    {
        // >> Mapper
        IdiomaMapper mapper;
        // >> Constructor
        public IdiomaCrudFactory() : base()
        {
            mapper = new IdiomaMapper();
            dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public override void Create(BaseEntity entity)
        {
            var idioma = (Idioma)entity;
            var sqlOperation = mapper.GetCreateStatement(idioma);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Create & Retrieve
        public T Create<T>(BaseEntity entity)
        {
            var pedido = (Idioma)entity;
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
        // >> Update
        public override void Update(BaseEntity entity)
        {
            var idioma = (Idioma)entity;
            var sqlOperation = mapper.GetUpdateStatement(idioma);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >> Update & Retrieve
        public T Update<T>(BaseEntity entity)
        {
            var pedido = (Idioma)entity;
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
            var idioma = (Idioma)entity;
            var sqlOperation = mapper.GetDeleteStatement(idioma);
            dao.ExecuteProcedure(sqlOperation);
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Obtener mas popular
        public T RetrieveMasPopular<T>()
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveMasPopularStatement());
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
