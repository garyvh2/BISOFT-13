using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;
using Entities.Classes;
using System.Data;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Entities;
using Entities.Entities.TransactionEntities;

namespace DataAccess.MAPPER.TransactionComponents
{
    // >> ===================================================================================== <<
    // >> {Type}Mapper <<
    // >> Es la clase encargada de la prepacion de los metodos SQL con las debida propiedades de
    // >> un tipo
    // >> ===================================================================================== <<
    public class TransaccionMapper : BaseMapper<Transaccion>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List Tarjetas por usuario
        public SqlOperation GetRetriveAllByIdUsuarioStatement(BaseEntity entity)
        {
            var ProcedureName = "list_transaccion_by_usuario";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Usuario)entity;
            operation.AddVarcharParam("ID_USUARIO", c.Identificacion);

            return operation;

        }

        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}