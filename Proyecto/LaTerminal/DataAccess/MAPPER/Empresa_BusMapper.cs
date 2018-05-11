using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;
using Entities.Classes;
using System.Data;
using DataAccess.MAPPER.ArchitectureComponents;

namespace DataAccess.MAPPER
{
    // >> ===================================================================================== <<
    // >> {Type}Mapper <<
    // >> Es la clase encargada de la prepacion de los metodos SQL con las debida propiedades de
    // >> un tipo
    // >> ===================================================================================== <<
    public class Empresa_BusMapper : BaseMapper<Empresa_Bus>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public SqlOperation GetAsignarATerminalStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "asignar_empresa_buses" };

            var c = (Empresa_Bus)entity;
            operation.AddVarcharParam("ID_TERMINAL", c.ID_TERMINAL);
            operation.AddVarcharParam("ID_EMPRESA_BUS", c.CEDULA_JUR);

            return operation;
        }
        public SqlOperation GetDesasignarDeTerminalStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "desasignar_empresa_buses" };

            var c = (Empresa_Bus)entity;
            operation.AddVarcharParam("ID_TERMINAL", c.ID_TERMINAL);
            operation.AddVarcharParam("ID_EMPRESA_BUS", c.CEDULA_JUR);

            return operation;
        }
        public SqlOperation GetRetrieveAllGroupedByTerminal()
        {
            var ProcedureName = "list_empresa_bus_grouped_by_terminal";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            return operation;
        }

        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}
