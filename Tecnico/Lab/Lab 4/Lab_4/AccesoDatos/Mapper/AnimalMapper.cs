using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    public class AnimalMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID          = "ID";
        private const string DB_COL_NOMBRE      = "NOMBRE";
        private const string DB_COL_CATEGORIA   = "CATEGORIA";
        private const string DB_COL_EDAD        = "EDAD";
        private const string DB_COL_FECHA_NAC   = "FECHA_NACIMIENTO";
        private const string DB_COL_ALIMENTO    = "ALIMENTO";
        private const string DB_COL_GENERO = "GENERO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_animal" };

            var c = (Animal)entity;
            operation.AddVarcharParam   (DB_COL_NOMBRE,         c.Nombre);
            operation.AddVarcharParam   (DB_COL_CATEGORIA,      c.Categoria);
            operation.AddDoubleParam    (DB_COL_EDAD,           c.Edad);
            operation.AddDateTimeParam  (DB_COL_FECHA_NAC,      c.FechaNac);
            operation.AddVarcharParam   (DB_COL_ALIMENTO,       c.Alimento);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "find_animal" };

            var c = (Animal)entity;
            operation.AddIntParam       (DB_COL_ID,             c.Id);

            return operation;
        }
        public SqlOperation GetRetriveByNombreStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "find_animal_by_nombre" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "list_animal" };
            return operation;
        }

        public SqlOperation GetRetriveAllByCategoriaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_animal_by_categoria" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_CATEGORIA, c.Categoria);

            return operation;
        }

        public SqlOperation GetRetriveAllByNombreStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "list_animal_by_nombre" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_animal" };

            var c = (Animal)entity;
            operation.AddIntParam       (DB_COL_ID,             c.Id);
            operation.AddVarcharParam   (DB_COL_NOMBRE,         c.Nombre);
            operation.AddVarcharParam   (DB_COL_CATEGORIA,      c.Categoria);
            operation.AddDoubleParam    (DB_COL_EDAD,           c.Edad);
            operation.AddDateTimeParam  (DB_COL_FECHA_NAC,      c.FechaNac);
            operation.AddVarcharParam   (DB_COL_ALIMENTO,       c.Alimento);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_animal" };

            var c = (Animal)entity;
            operation.AddIntParam       (DB_COL_ID,             c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var animal = BuildObject(row);
                lstResults.Add(animal);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var animal = new Animal
            {
                Id          = GetIntValue       (row, DB_COL_ID),
                Nombre      = GetStringValue    (row, DB_COL_NOMBRE),
                Categoria   = GetStringValue    (row, DB_COL_CATEGORIA),
                Edad        = GetDoubleValue    (row, DB_COL_EDAD),
                FechaNac    = GetDateValue      (row, DB_COL_FECHA_NAC),
                Alimento    = GetStringValue    (row, DB_COL_ALIMENTO),
                Genero = GetStringValue(row, DB_COL_GENERO)
            };

            return animal;
        }

    }
}
