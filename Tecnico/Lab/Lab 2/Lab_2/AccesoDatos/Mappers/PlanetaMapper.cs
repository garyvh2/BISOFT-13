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
    public class PlanetaMapper : IMapper<Planeta>
    {
        public Planeta findById(int id)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("select_planeta").IsStoredProcedure();
                DB.SQLParam("@ID", id, SqlDbType.Int, 18);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
                return this.MapperSingle(_Reader);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Planeta> findBySistema(Sistema sistema)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("select_planetas_por_sistema").IsStoredProcedure();
                DB.SQLParam("@ID_SISTEMA", sistema._Id, SqlDbType.Int, 18);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
                return this.MapperMultiple(_Reader);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Planeta> findAll()
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("list_planetas").IsStoredProcedure();
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
                return this.MapperMultiple(_Reader);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void insert(Planeta planeta)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("insertar_planeta").IsStoredProcedure();
                DB.SQLParam("@ID_SISTEMA", planeta._IdSistema, SqlDbType.Int, 18);
                DB.SQLParam("@NOMBRE", planeta._Nombre, SqlDbType.VarChar, 50);
                DB.SQLParam("@SUNDISTANCE", planeta._SunDistance, SqlDbType.Int, 50);
                DB.SQLParam("@FECHA", planeta._Fecha, SqlDbType.DateTime);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {

            }
        }
        public void update(Planeta planeta)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("update_planeta").IsStoredProcedure();
                DB.SQLParam("@ID", planeta._Id, SqlDbType.Int, 18);
                DB.SQLParam("@ID_SISTEMA", planeta._IdSistema, SqlDbType.Int, 18);
                DB.SQLParam("@NOMBRE", planeta._Nombre, SqlDbType.VarChar, 50);
                DB.SQLParam("@SUNDISTANCE", planeta._SunDistance, SqlDbType.Int, 50);
                DB.SQLParam("@FECHA", planeta._Fecha, SqlDbType.DateTime);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {
            }
        }
        public void delete(Planeta planeta)
        {
            try
            {
                Conexion DB = new Conexion();
                DB.Bootstrap();
                DB.SQLQuery("delete_planeta").IsStoredProcedure();
                DB.SQLParam("@ID", planeta._Id, SqlDbType.Int, 18);
                SqlDataReader _Reader = DB.ExecuteStoredProcedure();
            }
            catch (Exception ex)
            {

            }
        }
        public Planeta MapperSingle(SqlDataReader _Reader)
        {
            Planeta planeta = new Planeta();
            try
            {
                if ((_Reader.HasRows))
                {
                    while (_Reader.Read())
                    {
                        planeta._Id = Int32.Parse(_Reader["ID"].ToString());
                        planeta._IdSistema = Int32.Parse(_Reader["ID_SISTEMA"].ToString());
                        planeta._Nombre = _Reader["NOMBRE"].ToString();
                        planeta._SunDistance = Int32.Parse(_Reader["SUNDISTANCE"].ToString());
                        planeta._Fecha = DateTime.Parse(_Reader["FECHA"].ToString());
                    }
                    return planeta;
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
        public List<Planeta> MapperMultiple(SqlDataReader _Reader)
        {
            try
            {
                List<Planeta> planetas = new List<Planeta>();
                if ((_Reader.HasRows))
                {
                    while (_Reader.Read())
                    {
                        Planeta planeta = new Planeta();
                        planeta._Id = Int32.Parse(_Reader["ID"].ToString());
                        planeta._IdSistema = Int32.Parse(_Reader["ID_SISTEMA"].ToString());
                        planeta._Nombre = _Reader["NOMBRE"].ToString();
                        planeta._SunDistance = Int32.Parse(_Reader["SUNDISTANCE"].ToString());
                        planeta._Fecha = DateTime.Parse(_Reader["FECHA"].ToString());
                        planetas.Add(planeta);
                    }

                    return planetas;
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
