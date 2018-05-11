using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAO;
using Entidades;
using Entidades.Classes;

namespace AccesoDatos.Mapper
{
    public class IdiomaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CODIGO = "CODIGO";
        private const string DB_COL_NOMBRE = "NOMBRE";

        // >> Parametros de consulta
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_idioma" };

            var c = (Idioma)entity;
            operation.AddVarcharParam(DB_COL_CODIGO, c.Codigo);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);

            return operation;
        }
        // >> Read
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_idioma" };

            var c = (Idioma)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }
        // >> List
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_idioma" };
            return operation;
        }
        // >> Update
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_idioma" };

            var c = (Idioma)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_CODIGO, c.Codigo);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);

            return operation;
        }
        // >> Delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_idioma" };

            var c = (Idioma)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Idioma mas popular
        public SqlOperation GetRetriveMasPopularStatement()
        {
            var operation = new SqlOperation { ProcedureName = "select_idioma_mas_popular" };
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
                var idioma = BuildObject(row);
                lstResults.Add(idioma);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var idioma = new Idioma
            {
                Id = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Codigo = GetStringValue(row, DB_COL_CODIGO),
                Popularidad = GetIntValue(row, DB_COL_POPULARIDAD)
            };

            return idioma;
        }
    }
}
