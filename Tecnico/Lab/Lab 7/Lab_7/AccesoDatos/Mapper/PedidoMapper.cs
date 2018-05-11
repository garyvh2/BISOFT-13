using AccesoDatos.DAO;
using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    public class PedidoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_COMERCIO = "COMERCIO";
        private const string DB_COL_DIRECCION = "DIRECCION";
        private const string DB_COL_TOTAL = "TOTAL";
        private const string DB_COL_ESTADO = "ESTADO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_pedido" };

            var c = (Pedido)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_COMERCIO, c.Comercio);
            operation.AddVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddDoubleParam(DB_COL_TOTAL, c.Total);
            operation.AddIntParam(DB_COL_ESTADO, (int)c.Estado);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "find_pedido" };

            var c = (Pedido)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_pedido" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_pedido" };

            var c = (Pedido)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddDateTimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_COMERCIO, c.Comercio);
            operation.AddVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddDoubleParam(DB_COL_TOTAL, c.Total);
            operation.AddIntParam(DB_COL_ESTADO, (int)c.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_pedido" };

            var c = (Pedido)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var pedido = BuildObject(row);
                lstResults.Add(pedido);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var pedido = new Pedido
            {
                Id = GetIntValue(row, DB_COL_ID),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Comercio = GetStringValue(row,DB_COL_COMERCIO),
                Direccion = GetStringValue(row,DB_COL_DIRECCION),
                Total = GetDoubleValue(row,DB_COL_TOTAL),
                Estado = (EstadoPedido)GetIntValue(row,DB_COL_ESTADO)
            };

            return pedido;
        }
    }
}
