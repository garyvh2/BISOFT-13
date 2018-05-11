using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAO;
using Entidades;

namespace AccesoDatos.Mapper
{
    public class LineaDetalleMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID          = "ID";
        private const string DB_COL_ID_TIPO     = "ID_TIPO";
        private const string DB_COL_ID_PEDIDO   = "ID_PEDIDO";
        private const string DB_COL_NOMBRE      = "NOMBRE";
        private const string DB_COL_CANTIDAD    = "CANTIDAD";
        private const string DB_COL_TOTAL       = "TOTAL";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_linea_detalle" };

            var c = (LineaDetalle)entity;
            operation.AddIntParam(DB_COL_ID_TIPO, c.IdTipo);
            operation.AddIntParam(DB_COL_ID_PEDIDO, c.IdPedido);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CANTIDAD, c.Cantidad);
            operation.AddDoubleParam(DB_COL_TOTAL, c.Total);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "find_linea_detalle" };

            var c = (LineaDetalle)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_linea_detalle" };
            return operation;
        }

        public SqlOperation GetRetriveAllByPedidoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_linea_detalle_by_pedido" };

            var c = (Pedido)entity;
            operation.AddIntParam(DB_COL_ID_PEDIDO, c.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_linea_detalle" };

            var c = (LineaDetalle)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddIntParam(DB_COL_ID_TIPO, c.IdTipo);
            operation.AddIntParam(DB_COL_ID_PEDIDO, c.IdPedido);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CANTIDAD, c.Cantidad);
            operation.AddDoubleParam(DB_COL_TOTAL, c.Total);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_linea_detalle" };

            var c = (LineaDetalle)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var lineaDetalle = BuildObject(row);
                lstResults.Add(lineaDetalle);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var lineaDetalle = new LineaDetalle
            {
                Id = GetIntValue(row, DB_COL_ID),
                IdTipo = GetIntValue(row, DB_COL_ID_TIPO),
                IdPedido = GetIntValue(row, DB_COL_ID_PEDIDO),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cantidad = GetDoubleValue(row, DB_COL_CANTIDAD),
                Total = GetDoubleValue(row, DB_COL_TOTAL)
            };

            return lineaDetalle;
        }
    }
}
