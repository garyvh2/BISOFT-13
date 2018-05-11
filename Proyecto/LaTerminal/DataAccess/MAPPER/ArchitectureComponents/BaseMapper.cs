using DataAccess.DAO;
using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER.ArchitectureComponents
{
    // >> ===================================================================================== <<
    // >> {Type}Mapper <<
    // >> Es la clase encargada de la prepacion de los metodos SQL con las debida propiedades de
    // >> un tipo
    // >> ===================================================================================== <<
    public abstract class BaseMapper<T> : EntityMapper where T : BaseEntity, new()
    {
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public virtual SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var ProcedureName = "insert_" + getTableName(entity);
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            return addParams(operation, entity, false);
        }
        // >> Read
        public virtual SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var ProcedureName = "select_" + getTableName(entity);
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            return addIdentity(operation, entity);
        }
        // >> List
        public virtual SqlOperation GetRetriveAllStatement()
        {
            var obj = new T();

            var ProcedureName = "list_" + getTableName(obj);
            var operation = new SqlOperation { ProcedureName = ProcedureName };
            return operation;
        }
        // >> Update
        public virtual SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var ProcedureName = "update_" + getTableName(entity);
            var operation = new SqlOperation { ProcedureName = ProcedureName };


            return addParams(operation, entity, true);
        }
        // >> Delete
        public virtual SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var ProcedureName = "delete_" + getTableName(entity);
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            return addIdentity(operation, entity);
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
                var example = BuildObject(row);
                lstResults.Add(example);
            }

            return lstResults;
        }
        // >> Single
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            // >> Instanciate a new object
            var obj = new T();
            // >> Get the properties information
            var propertiesInfo = obj.GetLiteralProperties<IsEntityProperty>();

            foreach (var p in propertiesInfo)
            {
                // >> Obtain the property type
                var type = p.PropertyType;
                // >> Obtain the property type code
                var typeCode = Type.GetTypeCode(type);

                // >> Based on the type code proceed to extract the values
                switch (typeCode)
                {
                    case TypeCode.DBNull:
                        obj[p.Name] = null;
                        break;
                    case TypeCode.String:
                        obj[p.Name] = GetStringValue(row, p.Name.ToUpper());
                        break;
                    case TypeCode.Single:
                        obj[p.Name] = GetFloatValue(row, p.Name.ToUpper());
                        break;
                    case TypeCode.Double:
                        obj[p.Name] = GetDoubleValue(row, p.Name.ToUpper());
                        break;
                    case TypeCode.DateTime:
                        obj[p.Name] = GetDateValue(row, p.Name.ToUpper());
                        break;
                    case TypeCode.Int32:
                        obj[p.Name] = GetIntValue(row, p.Name.ToUpper());
                        break;
                    case TypeCode.Boolean:
                        obj[p.Name] = GetBooleanValue(row, p.Name.ToUpper());
                        break;
                }
            }

            return obj;
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Get kind default value
        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        // >> Get Table name
        private string getTableName(BaseEntity entity)
        {
            return entity.GetClassAttributeValue<DBTable, string>("name");
        }
        // >> Process Params based on the item properties
        private SqlOperation addParams(SqlOperation operation, BaseEntity entity, bool update)
        {
            // >> Cast the Entity
            var obj = (T)entity;
            // >> Obtain the object Identity
            var identity = obj.GetPropertiesWithAttribute<IsIdentity>()[0];
            // >> Check if the identity must be included (Auto Increase table shouldn't have it on create)
            var includeIdentity = obj.GetPropertyAttributeValue<IsIdentity, bool>("IncludeMapper", identity);
            // >> Get the entity properties
            var properties = obj.GetPropertiesWithAttribute<IsEntityProperty>();

            foreach (var p in properties)
            {
                // >> If the property is the identity and the identity shouldn't be included or this is not an update
                // >> then the identity is skipped
                if (p == identity && !includeIdentity && !update) continue;

                // >> Nullable
                var nullable = obj.GetPropertyAttributeValue<IsEntityProperty, bool>("IsNullable", p);

                // >> Only used on Retrieve
                var only_retrieve = obj.GetPropertyAttributeValue<IsEntityProperty, bool>("OnlyRetrieve", p);
                if (only_retrieve) continue;

                // >> Get the value
                var value = obj[p];

                // >> Depending on the value type proceed to add the operation 
                switch (value)
                {
                    case null:
                        if (nullable) operation.AddNullParam(p.ToUpper(), SqlDbType.VarChar);
                        break;
                    case String StringValue:
                        operation.AddVarcharParam(p.ToUpper(), StringValue);
                        break;
                    case float FloatValue:
                        operation.AddFloatParam(p.ToUpper(), FloatValue);
                        break;
                    case Double DoubleValue:
                        operation.AddDoubleParam(p.ToUpper(), DoubleValue);
                        break;
                    case DateTime DateTimeValue:
                        operation.AddDateTimeParam(p.ToUpper(), DateTimeValue);
                        break;
                    case int IntValue:
                        operation.AddIntParam(p.ToUpper(), IntValue);
                        break;
                    case Boolean BoolValue:
                        operation.AddBitParam(p.ToUpper(), BoolValue);
                        break;
                }
            }

            return operation;
        }
        // >> Add the Id based on the identity value
        private SqlOperation addIdentity(SqlOperation operation, BaseEntity entity)
        {
            // >> Cast the entity
            var obj = (T)entity;
            // >> Get the identity value
            var identity = obj.GetPropertiesWithAttribute<IsIdentity>();

            foreach (var i in identity)
            {
                // >> Substract the identity
                var value = obj[i];
                // >> Based on the kind add the value
                switch (value)
                {
                    case String StringValue:
                        operation.AddVarcharParam(i.ToUpper(), StringValue);
                        break;
                    case float FloatValue:
                        operation.AddFloatParam(i.ToUpper(), FloatValue);
                        break;
                    case Double DoubleValue:
                        operation.AddDoubleParam(i.ToUpper(), DoubleValue);
                        break;
                    case DateTime DateTimeValue:
                        operation.AddDateTimeParam(i.ToUpper(), DateTimeValue);
                        break;
                    case int IntValue:
                        operation.AddIntParam(i.ToUpper(), IntValue);
                        break;
                    case Boolean BoolValue:
                        operation.AddBitParam(i.ToUpper(), BoolValue);
                        break;
                }
            }

            return operation;
        }
    }
}
