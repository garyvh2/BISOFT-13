using DataAccess.DAO;
using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER.ArchitectureComponents
{
    // >> ===================================================================================== <<
    // >> {Type}Mapper <<
    // >> Es la clase encargada de la prepacion de los metodos SQL con las debida propiedades de
    // >> un tipo
    // >> ===================================================================================== <<
    public class ListValueMapper : BaseMapper<ListValue>, ISqlStaments, IObjectMapper
    {

        // >> Parametros de consulta

        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List Values
        public SqlOperation GetRetriveAllByIdListaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_lista" };

            var c = (ListValue)entity;
            operation.AddVarcharParam("ID_LISTA", c.Id_Lista);

            return operation;
        }


        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
    }
}
