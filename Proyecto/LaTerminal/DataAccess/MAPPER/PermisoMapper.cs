using DataAccess.DAO;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    // >> ===================================================================================== <<
    // >> {Type}Mapper <<
    // >> Es la clase encargada de la prepacion de los metodos SQL con las debida propiedades de
    // >> un tipo
    // >> =====================================================================================
    public class PermisoMapper : BaseMapper<Permiso>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public SqlOperation GetRetriveAllByRolStatement(BaseEntity entity)
        {
            var ProcedureName = "list_permiso_by_rol";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Rol)entity;
            operation.AddVarcharParam("ID_ROL", c.Id);

            return operation;

        }

        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}
