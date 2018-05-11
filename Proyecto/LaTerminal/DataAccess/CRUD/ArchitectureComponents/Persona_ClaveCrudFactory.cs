using DataAccess.DAO;
using DataAccess.MAPPER;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD.ArchitectureComponents
{

    // >> ===================================================================================== <<
    // >> {Type}CrudFactory <<
    // >> Es la clase encargada de exponer los metodos de consulta al base de datos de 
    // >> para la arquitectura
    // >> ===================================================================================== <<
    public class Persona_ClaveCrudFactory : CrudFactory<Persona_Clave, Persona_ClaveMapper>
    {
        // >> Constructor
        public Persona_ClaveCrudFactory() : base()
        {
            base.mapper = new Persona_ClaveMapper();
            base.dao = SqlDao.GetInstance();
        }
        // >>=========================================================================<<
        // >> Additional Operations 
        // >>=========================================================================<<
        public List<Persona_Clave> UltimasClaves(BaseEntity entity)
        {
            var list = new List<Persona_Clave>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.UltimasClaves(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    list.Add((Persona_Clave)Convert.ChangeType(c, typeof(Persona_Clave)));
                }
            }

            return list;
        }
    }
}
