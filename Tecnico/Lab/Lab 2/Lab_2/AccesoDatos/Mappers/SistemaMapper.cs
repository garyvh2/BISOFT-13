using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos.Models;

namespace AccesoDatos.Mappers
{
    public class SistemaMapper : IMapper<Sistema>
    {
        public Sistema findById(int id)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("select_sistema").IsStoredProcedure();
                DB.SQLParam("@ID", id, SqlDbType.Int, 18);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
                return this.MapperSingle(_Reader);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Sistema> findAll()
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("list_sistemas").IsStoredProcedure();
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
                return this.MapperMultiple(_Reader);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void insert(Sistema sistema)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("insertar_sistema").IsStoredProcedure();
                DB.SQLParam("@NOMBRE", sistema._Nombre, SqlDbType.VarChar, 50);
                DB.SQLParam("@FECHA", sistema._Fecha, SqlDbType.DateTime);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {

            }
        }
        public void update(Sistema sistema)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("update_sistema").IsStoredProcedure();
                DB.SQLParam("@ID", sistema._Id, SqlDbType.Int, 18);
                DB.SQLParam("@NOMBRE", sistema._Nombre, SqlDbType.VarChar, 50);
                DB.SQLParam("@FECHA", sistema._Fecha, SqlDbType.DateTime);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {
            }
        }
        public void delete(Sistema sistema)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("delete_sistema").IsStoredProcedure();
                DB.SQLParam("@ID", sistema._Id, SqlDbType.Int, 18);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {

            }
        }
        public Sistema MapperSingle(SqlDataReader _Reader)
        {
            Sistema sistema = new Sistema();
            try
            {
                if ((_Reader.HasRows))
                {
                    while (_Reader.Read())
                    {
                        sistema._Id = Int32.Parse(_Reader["ID"].ToString());
                        sistema._Nombre = _Reader["NOMBRE"].ToString();
                        sistema._Fecha = DateTime.Parse(_Reader["FECHA"].ToString());
                    }
                    return sistema;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Sistema> MapperMultiple(SqlDataReader _Reader)
        {
            try
            {
                List<Sistema> sistemas = new List<Sistema>();
                if ((_Reader.HasRows))
                {
                    while (_Reader.Read())
                    {
                        Sistema sistema = new Sistema();
                        sistema._Id = Int32.Parse(_Reader["ID"].ToString());
                        sistema._Nombre = _Reader["NOMBRE"].ToString();
                        sistema._Fecha = DateTime.Parse(_Reader["FECHA"].ToString());
                        sistemas.Add(sistema);
                    }

                    return sistemas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
