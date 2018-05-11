using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

    // >> ===================================================================================== <<
    // >> SQL Dao (Data Access Object) <<
    // >> Es la clase a cargo de la conexion y comunicacion con la base de datos
    // >> ===================================================================================== <<
    public class SqlDao
    {
        // >> Constante de referencia a la conexion con la base de datos
        private string CONNECTION_STRING = "";

        // >> Instancia Singleton
        private static SqlDao instance;

        private SqlDao()
        {
            SqlConnectionStringBuilder builder = null;
            if (ConfigurationManager.AppSettings["DB_Environment"] == "production")
            {
                builder = new SqlConnectionStringBuilder
                {
                    DataSource = System.Environment.GetEnvironmentVariable("Azure_DataSource") ?? ConfigurationManager.AppSettings["Azure_DataSource"],
                    UserID = System.Environment.GetEnvironmentVariable("Azure_UserID") ?? ConfigurationManager.AppSettings["Azure_UserID"],
                    Password = System.Environment.GetEnvironmentVariable("Azure_Password") ?? ConfigurationManager.AppSettings["Azure_Password"],
                    InitialCatalog = System.Environment.GetEnvironmentVariable("Azure_InitialCatalog") ?? ConfigurationManager.AppSettings["Azure_InitialCatalog"]
                };

                CONNECTION_STRING = builder.ConnectionString;
            }
            else if (ConfigurationManager.AppSettings["DB_Environment"] == "dev")
            {
                builder = new SqlConnectionStringBuilder
                {
                    DataSource = System.Environment.GetEnvironmentVariable("Azure_DataSource") ?? ConfigurationManager.AppSettings["Local_DataSource"],
                    InitialCatalog = System.Environment.GetEnvironmentVariable("Azure_InitialCatalog") ?? ConfigurationManager.AppSettings["Local_InitialCatalog"],
                    IntegratedSecurity = true,
                    Pooling = false
                };
            }
            CONNECTION_STRING = builder.ConnectionString;
        }
        // >> Obtener instancia
        public static SqlDao GetInstance()
        {
            // >> Si no existe crear una nueva instancia
            if (instance == null)
                instance = new SqlDao();
            // >> Retornar una instancia
            return instance;
        }

        // >> Ejecutar un procedimiento almacenado
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            // >> Instancia de conexion
            using (var conn = new SqlConnection(CONNECTION_STRING))
            // >> Instancia del commando de SQL
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                // >> Se agregan los parametros a la consulta
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }
                // >> La conexion es abierta
                conn.Open();
                // >> Y se ejecuta el procedimiento
                command.ExecuteNonQuery();
            }
        }
        // >> Se ejecuta un procedimiento almacenado substrayendo informacion con el mismo
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            // >> Lista de valores a retornar
            // >> Los datos son retornados en una lista de diccionarios que poseen el nombre de la propiedad y el valor de esta
            var lstResult = new List<Dictionary<string, object>>();
            // >> Instancia de conexion
            using (var conn = new SqlConnection(CONNECTION_STRING))
            // >> Instancia del comando de SQL
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                // >> Se agregan los parametros a la consulta
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }
                // >> Se abre la conexion
                conn.Open();
                // >> Se obtiene el reader de filas provenientes de la base de datos
                // >> Es cual es retornado por la consulta
                var reader = command.ExecuteReader();
                // >> Si hay filas retornadas por la consulta
                if (reader.HasRows)
                {
                    // >> Se lee cada una de ellas
                    while (reader.Read())
                    {
                        // >> Se instancia un diccionario
                        var dict = new Dictionary<string, object>();
                        for (var lp = 0; lp < reader.FieldCount; lp++)
                        {
                            // >> Y por cada columna en la fila se agrega un valor al diccionario
                            dict.Add(reader.GetName(lp), reader.GetValue(lp));
                        }
                        // >> Se almacenan los valores de la fila
                        lstResult.Add(dict);
                    }
                }
            }

            return lstResult;
        }
    }
}
