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
    // >> ===================================================================================== <<
    public class TarjetaMapper : BaseMapper<Tarjeta>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        // >> Get Tarjeta Con Id Usuario
        public SqlOperation GetRetriveWithIdUsuarioStatement(BaseEntity entity)
        {
            var ProcedureName = "select_tarjeta_with_id_usuario";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Tarjeta)entity;
            operation.AddVarcharParam("CODIGO", c.Codigo);
            operation.AddVarcharParam("ID_USUARIO", c.Id_Usuario);

            return operation;

        }
        
        // >> List Tarjetas por usuario
        public SqlOperation GetRetriveAllByIdUsuarioStatement(BaseEntity entity)
        {
            var ProcedureName = "list_tarjeta_by_id_usuario";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Tarjeta)entity;
            operation.AddVarcharParam("ID_USUARIO", c.Id_Usuario);

            return operation;

        }
        // >> List Tarjetas por usuario
        public SqlOperation GetRetriveByUsuarioTerminalTipoStatement(BaseEntity entity)
        {
            var ProcedureName = "select_tarjeta_by_user_terminal_tipo";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Tarjeta)entity;
            operation.AddVarcharParam("ID_USUARIO", c.Id_Usuario);
            operation.AddVarcharParam("ID_TERMINAL", c.Id_Terminal);
            operation.AddVarcharParam("ID_TIPO", c.Id_Tipo);

            return operation;

        }
        // >> Actualizar Saldo
        public SqlOperation ActualizarSaldo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_tarjeta_saldo" };

            var c = (Tarjeta)entity;
            operation.AddVarcharParam("CODIGO", c.Codigo);
            operation.AddFloatParam("SALDO", c.Saldo);

            return operation;
        }
        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}
