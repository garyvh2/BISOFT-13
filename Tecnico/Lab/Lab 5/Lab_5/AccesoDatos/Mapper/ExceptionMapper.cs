using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAO;
using Entidades;

namespace AccesoDatos.Mapper
{
    public class ExceptionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CODE = "CODE";
        private const string DB_COL_MESSAGE = "MESSAGE";
        private const string DB_COL_STACKTRACE = "STACKTRACE";
        private const string DB_COL_DATE = "DATE";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_exception" };

            var c = (AppException)entity;
            operation.AddIntParam(DB_COL_CODE, c.Code);
            operation.AddVarcharParam(DB_COL_MESSAGE, c.Message);
            operation.AddVarcharParam(DB_COL_STACKTRACE, c.Stacktrace);
            operation.AddDateTimeParam(DB_COL_DATE, c.Date);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException(); ;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }
    }
}
