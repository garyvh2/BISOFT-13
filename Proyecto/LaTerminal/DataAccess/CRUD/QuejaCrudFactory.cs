using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class QuejaCrudFactory : CrudFactory<Queja, QuejaMapper>
    {
        public QuejaCrudFactory() : base()
        {
            base.mapper = new QuejaMapper();
            base.dao = SqlDao.GetInstance();
        }

    }
}
