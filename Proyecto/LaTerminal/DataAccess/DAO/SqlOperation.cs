using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    // >> ===================================================================================== <<
    // >> SQL Operation <<
    // >> Es la clase a cargo del procesamientos de operaciones de SQL
    // >> ===================================================================================== <<
    public class SqlOperation
    {
        // >> Nombre del procedimiento a ejecutar
        public string ProcedureName { get; set; }
        // >> Parametros del procedimiento
        public List<SqlParameter> Parameters { get; set; }

        // >> Una nueva instancia de SqlOperation va a crear una nueva lista de parametros
        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }
        // >> ===================================================================================== <<
        // >> Agregacion y procesamiento de palametros de operaciones de SQL <<
        // >> ===================================================================================== <<
        // >> Agregar un parametro null
        public void AddNullParam(string paramName, SqlDbType paramType)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, paramType)
            {
                Value = DBNull.Value
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar un String parametro como Varchar
        public void AddVarcharParam(string paramName, string paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar un Int como parametro Int
        public void AddBitParam(string paramName, bool paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Bit)
            {
                Value = Convert.ToInt32(paramValue)
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar un Int como parametro Int
        public void AddIntParam(string paramName, int paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar un Double como parametro Float
        public void AddDoubleParam(string paramName, double paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Float)
            {
                Value = paramValue
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar un Double como parametro Float
        public void AddFloatParam(string paramName, float paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Float)
            {
                Value = paramValue
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
        // >> Agregar una fecha como parametro DateTime
        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            // >> Se crea un nuevo parametro de SQL, se recibe el nombre de la propiedad 
            //    y el valor como parametro
            var param = new SqlParameter("@P_" + paramName, SqlDbType.DateTime)
            {
                Value = paramValue
            };
            // >> Se agrega el parametro a la lista para esta operacion
            Parameters.Add(param);
        }
    }
}
