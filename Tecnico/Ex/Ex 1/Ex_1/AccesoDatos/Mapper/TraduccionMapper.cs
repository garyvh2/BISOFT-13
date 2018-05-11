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
    public class TraduccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        // >> Campos de CRUD
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_IDIOMA_ORIGINAL = "IDIOMA_ORIGINAL";
        private const string DB_COL_IDIOMA_DESTINO = "IDIOMA_DESTINO";
        private const string DB_COL_FRASE_ORIGINAL = "FRASE_ORIGINAL";
        private const string DB_COL_FRASE_TRADUCIDA = "FRASE_TRADUCIDA";
        private const string DB_COL_POPULARIDAD_TOTAL = "POPULARIDAD_TOTAL";
        private const string DB_COL_FECHA = "FECHA";

        // >> Campos de consulta
        private const string DB_COL_ID_TRADUCCION = "ID_TRADUCCION";
        private const string DB_COL_ID_IDIOMA = "ID_IDIOMA";

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_traduccion" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_ID_USUARIO, c.Id_Usuario);
            operation.AddIntParam(DB_COL_IDIOMA_ORIGINAL, c.Idioma_Original);
            operation.AddIntParam(DB_COL_IDIOMA_DESTINO, c.Idioma_Destino);
            operation.AddVarcharParam(DB_COL_FRASE_ORIGINAL, c.Frase_Original);
            operation.AddVarcharParam(DB_COL_FRASE_TRADUCIDA, c.Frase_Traducida);
            operation.AddIntParam(DB_COL_POPULARIDAD_TOTAL, c.Popularidad_Total);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);

            return operation;
        }
        // >> Read
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_traduccion" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id); 

            return operation;
        }
        // >> List
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_traduccion" };
            return operation;
        }
        // >> Update
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_traduccion" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddIntParam(DB_COL_ID_USUARIO, c.Id_Usuario);
            operation.AddIntParam(DB_COL_IDIOMA_ORIGINAL, c.Idioma_Original);
            operation.AddIntParam(DB_COL_IDIOMA_DESTINO, c.Idioma_Destino);
            operation.AddVarcharParam(DB_COL_FRASE_ORIGINAL, c.Frase_Original);
            operation.AddVarcharParam(DB_COL_FRASE_TRADUCIDA, c.Frase_Traducida);
            operation.AddIntParam(DB_COL_POPULARIDAD_TOTAL, c.Popularidad_Total);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);

            return operation;
        }
        // >> Delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_traduccion" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Calcular Popularidad
        public SqlOperation GetRetriveCalcularPopularidadStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "calcular_popularidad_traduccion_por_idioma" };

            var c = (Traduccion)entity;
            operation.AddIntParam(DB_COL_ID_IDIOMA, c.Id_Idioma);
            operation.AddIntParam(DB_COL_ID_TRADUCCION, c.Id_Traduccion);

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
                var traduccion = BuildObject(row);
                lstResults.Add(traduccion);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var traduccion = new Traduccion
            {
                Id = GetIntValue(row, DB_COL_ID),
                Id_Usuario = GetIntValue(row, DB_COL_ID_USUARIO),
                Idioma_Original = GetIntValue(row, DB_COL_IDIOMA_ORIGINAL),
                Idioma_Destino = GetIntValue(row, DB_COL_IDIOMA_DESTINO),
                Frase_Original = GetStringValue(row, DB_COL_FRASE_ORIGINAL),
                Frase_Traducida = GetStringValue(row, DB_COL_FRASE_TRADUCIDA),
                Popularidad_Total = GetIntValue(row, DB_COL_POPULARIDAD_TOTAL),
                Fecha = GetDateValue(row, DB_COL_FECHA)
            };

            return traduccion;
        }
    }
}
