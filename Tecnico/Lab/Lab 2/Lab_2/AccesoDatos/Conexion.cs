using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class Conexion
{
    private SqlConnection connection;
    private string connStr;
    private SqlCommand command;
    public Conexion()
    {
        this.connStr = "Data Source=.;Initial Catalog=Laboratorio2;Integrated Security=True";
    }

    public Conexion Bootstrap()
    {
        try
        {
            this.connection = new SqlConnection(this.connStr);
            this.connection.Open();
            return this;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool CloseConnection()
    {
        try
        {
            this.connection.Close();
            this.connection.Dispose();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public Conexion SQLQuery(string commStr)
    {
        try
        {
            this.command = new SqlCommand(commStr, this.connection);
            return this;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Conexion IsStoredProcedure()
    {
        try
        {
            this.command.CommandType = CommandType.StoredProcedure;
            return this;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool SQLParam(string _name, object _value, SqlDbType _type, int _size = 0)
    {
        try
        {
            SqlParameter parameter;
            if ((_size != 0))
            {
                parameter = this.command.Parameters.Add(_name, _type, _size);
            }
            else
            {
                parameter = this.command.Parameters.Add(_name, _type);
            }

            parameter.Value = _value;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public SqlDataReader ExecuteStoredProcedure()
    {
        try
        {
            SqlDataReader reader;
            this.command.Prepare();
            reader = this.command.ExecuteReader();
            command.CommandTimeout = 0;
            return reader;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}