using DataAccess.DAO;
using DataAccess.MAPPER;
using Entities.Classes;
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
    public class HorariosCrudFactory : CrudFactory<Horarios, HorariosMapper>
    {
        // >> Constructor
        public HorariosCrudFactory() : base()
        {
            base.mapper = new HorariosMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        public List<Horarios> listarAsignacion()
        {
            var lstHorarios = new List<Horarios>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.listarAsignacion());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstHorarios.Add((Horarios)Convert.ChangeType(c, typeof(Horarios)));
                }
            }

            return lstHorarios;
        }
    }
}
