using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    public class ProduccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID              = "ID";
        private const string DB_COL_ID_ANIMAL       = "ID_ANIMAL";
        private const string DB_COL_TIPO            = "TIPO";
        private const string DB_COL_CANTIDAD        = "CANTIDAD";
        private const string DB_COL_VALOR           = "VALOR";
        private const string DB_COL_FECHA_REG       = "FECHA_REGISTRO";

        // Consultas
        private const string DB_COL_RANGO_INICIAL   = "FECHA_INICIO";
        private const string DB_COL_RANGO_FINAL     = "FECHA_FIN";
        private const string DB_COL_CATEGORIA       = "CATEGORIA";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_produccion" };

            var c = (Produccion)entity;
            operation.AddIntParam       (DB_COL_ID_ANIMAL,  c.IdAnimal);
            operation.AddVarcharParam   (DB_COL_TIPO,       c.Tipo);
            operation.AddDoubleParam    (DB_COL_CANTIDAD,   c.Cantidad);
            operation.AddDoubleParam    (DB_COL_VALOR,      c.Valor);
            operation.AddDateTimeParam  (DB_COL_FECHA_REG,  c.FechaReg);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "find_produccion" };

            var c = (Produccion)entity;
            operation.AddIntParam       (DB_COL_ID,         c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_produccion" };
            return operation;
        }
        public SqlOperation GetRetriveAllByAnimalStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_produccion_by_animal" };

            var c = (Animal)entity;
            operation.AddIntParam       (DB_COL_ID_ANIMAL,  c.Id);

            return operation;
        }
        public SqlOperation GetRetriveAllByRangoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_produccion_by_rango" };

            var c = (Produccion)entity;
            operation.AddDateTimeParam  (DB_COL_RANGO_INICIAL,  c.RangoInicial);
            operation.AddDateTimeParam  (DB_COL_RANGO_FINAL,    c.RangoFinal);

            return operation;
        }
        public SqlOperation GetRetriveAllByRangoCategoriaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_produccion_by_rango_categoria" };

            var c = (Produccion)entity;
            operation.AddDateTimeParam  (DB_COL_RANGO_INICIAL,  c.RangoInicial);
            operation.AddDateTimeParam  (DB_COL_RANGO_FINAL,    c.RangoFinal);
            operation.AddVarcharParam   (DB_COL_CATEGORIA,      c.CategoriaAnimal);

            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_produccion" };

            var c = (Produccion)entity;
            operation.AddIntParam       (DB_COL_ID,         c.Id);
            operation.AddIntParam       (DB_COL_ID_ANIMAL,  c.IdAnimal);
            operation.AddVarcharParam   (DB_COL_TIPO,       c.Tipo);
            operation.AddDoubleParam    (DB_COL_CANTIDAD,   c.Cantidad);
            operation.AddDoubleParam    (DB_COL_VALOR,      c.Valor);
            operation.AddDateTimeParam  (DB_COL_FECHA_REG,  c.FechaReg);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_produccion" };

            var c = (Produccion)entity;
            operation.AddIntParam       (DB_COL_ID,         c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var produccion = BuildObject(row);
                lstResults.Add(produccion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var produccion = new Produccion
            {
                Id          = GetIntValue       (row, DB_COL_ID),
                IdAnimal    = GetIntValue       (row, DB_COL_ID_ANIMAL),
                Tipo        = GetStringValue    (row, DB_COL_TIPO),
                Cantidad    = GetDoubleValue    (row, DB_COL_CANTIDAD),
                Valor       = GetDoubleValue    (row, DB_COL_VALOR),
                FechaReg    = GetDateValue      (row, DB_COL_FECHA_REG)
            };

            return produccion;
        }

    }
}
