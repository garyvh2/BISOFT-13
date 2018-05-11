using DataAccess.DAO;
using DataAccess.MAPPER;
using DataAccess.MAPPER.TransactionComponents;
using Entities.Classes;
using Entities.Entities;
using Entities.Entities.TransactionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD.TransactionComponents
{
    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class TransaccionCrudFactory : CrudFactory<Transaccion, TransaccionMapper>
    {
        // >> Constructor
        public TransaccionCrudFactory() : base()
        {
            base.mapper = new TransaccionMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        // >> List Tarjetas Por ID Usuario
        public List<Transaccion> RetrieveAllByIdUsuario(BaseEntity entity)
        {
            var lstidiomas = new List<Transaccion>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByIdUsuarioStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstidiomas.Add((Transaccion)Convert.ChangeType(c, typeof(Transaccion)));
                }
            }

            return lstidiomas;
        }
    }
}
