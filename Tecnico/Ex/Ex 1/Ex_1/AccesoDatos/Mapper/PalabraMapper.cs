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
    public class PalabraMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_IDIOMA = "ID_IDIOMA";
        private const string DB_COL_ID_TRADUCTOR = "ID_TRADUCTOR";
        private const string DB_COL_FAMILIA = "FAMILIA";
        private const string DB_COL_PALABRA = "PALABRA";
        private const string DB_COL_FECHA = "FECHA";

        // >> Parametros adicionales
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";
        private const string DB_COL_DIA = "DIA";

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_palabra" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_ID_IDIOMA, c.Id_Idioma);
            operation.AddIntParam(DB_COL_ID_TRADUCTOR, c.Id_Traductor);
            operation.AddVarcharParam(DB_COL_FAMILIA, c.Familia);
            operation.AddVarcharParam(DB_COL_PALABRA, c._Palabra);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);

            return operation;
        }
        // >> Read
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_palabra" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }
        // >> Read By Palabra
        public SqlOperation GetRetriveByPalabraStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_palabra_by_palabra" };

            var c = (Palabra)entity;
            operation.AddVarcharParam(DB_COL_PALABRA, c._Palabra);

            return operation;
        }
        // >> Read By Familia & Idioma
        public SqlOperation GetRetriveByFamiliaAndIdiomaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_palabra_by_familia_and_idioma" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_ID_IDIOMA, c.Id_Idioma);
            operation.AddVarcharParam(DB_COL_FAMILIA, c.Familia);

            return operation;
        }
        // >> List
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_palabra" };
            return operation;
        }
        // >> List by idioma
        public SqlOperation GetRetriveAllByIdiomaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_palabra_by_idioma" };

            var c = (Idioma)entity;
            operation.AddIntParam(DB_COL_ID_IDIOMA, c.Id);

            return operation;
        }
        // >> Update
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_palabra" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddIntParam(DB_COL_ID_IDIOMA, c.Id_Idioma);
            operation.AddIntParam(DB_COL_ID_TRADUCTOR, c.Id_Traductor);
            operation.AddVarcharParam(DB_COL_FAMILIA, c.Familia);
            operation.AddVarcharParam(DB_COL_PALABRA, c._Palabra);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);

            return operation;
        }
        // >> Delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_palabra" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Top 100
        public SqlOperation GetRetriveTop100Statement()
        {
            var operation = new SqlOperation { ProcedureName = "select_top_palabras" };
            return operation;
        }
        // >> Top 10 Dia
        public SqlOperation GetRetriveTop10DiaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_top_palabras_by_dia" };

            var c = (Palabra)entity;
            operation.AddIntParam(DB_COL_DIA, c.DiaSemana);

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
                var palabra = BuildObject(row);
                lstResults.Add(palabra);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var palabra = new Palabra
            {
                Id = GetIntValue(row, DB_COL_ID),
                Id_Idioma = GetIntValue(row, DB_COL_ID_IDIOMA),
                Id_Traductor = GetIntValue(row, DB_COL_ID_TRADUCTOR),
                Familia = GetStringValue(row, DB_COL_FAMILIA),
                _Palabra = GetStringValue(row, DB_COL_PALABRA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Popularidad = GetIntValue(row,DB_COL_POPULARIDAD)
            };

            return palabra;
        }
    }
}
