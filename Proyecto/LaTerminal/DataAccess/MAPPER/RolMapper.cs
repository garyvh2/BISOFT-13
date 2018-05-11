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
    public class RolMapper : BaseMapper<Rol>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public SqlOperation GetAsignarPermisoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "asignar_permiso_rol" };

            var c = (Permiso)entity;
            operation.AddVarcharParam("ID_ROL", c.Id_Rol);
            operation.AddIntParam("ID_PERMISO", c.Id);

            return operation;
        }
        public SqlOperation GetDesasignarPermisoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "desasignar_permiso_rol" };

            var c = (Permiso)entity;
            operation.AddVarcharParam("ID_ROL", c.Id_Rol);
            operation.AddIntParam("ID_PERMISO", c.Id);

            return operation;
        }
        

        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}
