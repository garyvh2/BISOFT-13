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
    public class HorariosMapper : BaseMapper<Horarios>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public SqlOperation listarAsignacion()
        {
            var operation = new SqlOperation { ProcedureName = "LISTAR_ASIGNACION_BUS_HORARIO" };
            return operation;
        }
        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple

    }
}
