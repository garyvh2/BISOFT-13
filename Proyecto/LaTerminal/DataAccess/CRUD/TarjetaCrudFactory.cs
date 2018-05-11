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
    public class TarjetaCrudFactory : CrudFactory<Tarjeta, TarjetaMapper>
    {
        // >> Constructor
        public TarjetaCrudFactory() : base()
        {
            base.mapper = new TarjetaMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        // >> Get Tarjeta Por ID Usuario
        public Tarjeta RetrieveWithIdUsuario (BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveWithIdUsuarioStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Tarjeta)Convert.ChangeType(objs, typeof(Tarjeta));
            }

            return default(Tarjeta);
        }
        // >> List Tarjetas Por ID Usuario
        public List<Tarjeta> RetrieveAllByIdUsuario(BaseEntity entity)
        {
            var lstidiomas = new List<Tarjeta>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByIdUsuarioStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Tarjeta)Convert.ChangeType(c, typeof(Tarjeta)));
                }
            }

            return lstidiomas;
        }
        // >> Get Tarjeta Por Usuario, Terminal y Tipo
        public Tarjeta RetrieveByUsuarioTerminalTipo(BaseEntity entity)
        {
            var lstidiomas = new List<Tarjeta>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByUsuarioTerminalTipoStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Tarjeta)Convert.ChangeType(objs, typeof(Tarjeta));
            }

            return default(Tarjeta);
        }
        // >> Actualizar Saldo
        public Tarjeta ActualizarSaldo(BaseEntity entity)
        {
            var sqlOperation = mapper.ActualizarSaldo(entity);

            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Tarjeta)Convert.ChangeType(objs, typeof(Tarjeta));
            }
            return default(Tarjeta);
        }
    }
}
