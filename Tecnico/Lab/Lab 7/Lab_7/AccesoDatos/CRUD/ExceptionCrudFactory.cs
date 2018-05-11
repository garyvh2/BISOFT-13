using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DAO;
using AccesoDatos.Mapper;
using Entidades;

namespace AccesoDatos.CRUD
{
    public class ExceptionCrudFactory : CrudFactory
    {
        ExceptionMapper mapper;

        public ExceptionCrudFactory()
        {
            mapper = new ExceptionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var appException = (AppException)entity;
            var sqlOperation = mapper.GetCreateStatement(appException);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
