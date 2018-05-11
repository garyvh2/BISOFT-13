using AccesoDatos.DAO;
using AccesoDatos.Mapper;
using Entidades;
using Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.CRUD
{
    public class TraduccionPalabraCrudFactory : CrudFactory
    {
        // >> Mapper
        TraduccionPalabraMapper mapper;
        // >> Constructor
        public TraduccionPalabraCrudFactory() : base()
        {
            mapper = new TraduccionPalabraMapper();
            dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public override void Create(BaseEntity entity)
        {
            var traduccionPalabra = (TraduccionPalabra)entity;
            var sqlOperation = mapper.GetCreateStatement(traduccionPalabra);
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
