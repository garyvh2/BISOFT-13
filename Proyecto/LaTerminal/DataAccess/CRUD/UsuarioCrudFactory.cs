using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class UsuarioCrudFactory : CrudFactory<Usuario, UsuarioMapper>
    {
        // >> Constructor
        public UsuarioCrudFactory() : base()
        {
            base.mapper = new UsuarioMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        public Usuario RetrieveByTerminal(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByTerminalStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }

            return default(Usuario);
        }
        public Usuario RetrieveByCorreo(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByCorreoStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }

            return default(Usuario);
        }
        public Usuario Login(BaseEntity entity)
        {
            var sqlOperation = mapper.Login(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }
            return default(Usuario);
        }
        public Usuario CrearPasajero(BaseEntity entity)
        {
            var sqlOperation = mapper.CrearPasajero(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }
            return default(Usuario);
        }
        public Usuario ActualizarClave(BaseEntity entity)
        {
            var sqlOperation = mapper.ActualizarClave(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }
            return default(Usuario);
        }
        public Usuario ActualizarFoto(BaseEntity entity)
        {
            var sqlOperation = mapper.ActualizarFoto(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }
            return default(Usuario);
        }
        public Usuario AsignarTerminal(BaseEntity entity)
        {
            var sqlOperation = mapper.AsignarTerminal(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }
            return default(Usuario);
        }
        public List<Usuario> RetrieveAllByRol(BaseEntity entity)
        {
            var lstidiomas = new List<Usuario>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByRol(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Usuario)Convert.ChangeType(c, typeof(Usuario)));
                }
            }

            return lstidiomas;
        }
        public List<Usuario> RetrieveAllByTerminalOrEmpresa(BaseEntity entity)
        {
            var lstidiomas = new List<Usuario>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByTerminalOrEmpresa(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Usuario)Convert.ChangeType(c, typeof(Usuario)));
                }
            }

            return lstidiomas;
        }

        public Usuario RetrieveByRol(Usuario entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByRol(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Usuario)Convert.ChangeType(objs, typeof(Usuario));
            }

            return default(Usuario);
        }
    }
}