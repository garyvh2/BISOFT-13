﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAO;
using Entidades;
using Entidades.Classes;

namespace AccesoDatos.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO = "APELLIDO";

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_usuario" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);

            return operation;
        }
        // >> Read
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_usuario" };

            var c = (Usuario)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }
        // >> List
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_usuario" };
            return operation;
        }
        // >> Update
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_usuario" };

            var c = (Usuario)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);

            return operation;
        }
        // >> Delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_usuario" };

            var c = (Usuario)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var usuario = BuildObject(row);
                lstResults.Add(usuario);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                Id = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO)
            };

            return usuario;
        }
    }
}
