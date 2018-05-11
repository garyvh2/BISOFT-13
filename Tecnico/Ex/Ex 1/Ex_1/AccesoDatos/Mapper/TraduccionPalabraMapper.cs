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
    public class TraduccionPalabraMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_TRADUCCION = "ID_TRADUCCION";
        private const string DB_COL_ID_PALABRA = "ID_PALABRA";
        private const string DB_COL_ORDEN = "ORDEN";

        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_traducciones_palabras" };

            var c = (TraduccionPalabra)entity;
            operation.AddIntParam(DB_COL_ID_PALABRA, c.Id_Palabra);
            operation.AddIntParam(DB_COL_ID_TRADUCCION, c.Id_Traduccion);
            operation.AddIntParam(DB_COL_ORDEN, c.Orden);

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
                var traduccionPalabra = BuildObject(row);
                lstResults.Add(traduccionPalabra);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var traduccionPalabra = new TraduccionPalabra
            {
                Id_Palabra = GetIntValue(row, DB_COL_ID_PALABRA),
                Id_Traduccion = GetIntValue(row, DB_COL_ID_TRADUCCION),
                Orden = GetIntValue(row, DB_COL_ORDEN)
            };

            return traduccionPalabra;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
