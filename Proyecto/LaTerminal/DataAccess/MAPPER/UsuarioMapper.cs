using DataAccess.DAO;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class UsuarioMapper : BaseMapper<Usuario>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de consulta

        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public SqlOperation GetRetriveByCorreoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_usuario_by_correo" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("CORREO", c.Correo);

            return operation;
        }
        public SqlOperation GetRetriveByTerminalStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "select_usuario_by_terminal" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("ID_TERMINAL", c.Id_Terminal);
            operation.AddVarcharParam("ID_USUARIO", c.Identificacion);

            return operation;
        }
        public SqlOperation Login(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "login_usuario" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("Correo", c.Correo);
            operation.AddVarcharParam("Clave", c.Clave);

            return operation;
        }

        public SqlOperation CrearPasajero(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "insert_pasajero" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("IDENTIFICACION", c.Identificacion);
            operation.AddVarcharParam("CORREO", c.Correo);
            operation.AddVarcharParam("CLAVE", c.Clave);
            operation.AddVarcharParam("ID_ROL", c.Id_Rol);
            operation.AddBitParam("FIRST_TIME", c.First_Time);

            return operation;
        }
        public SqlOperation AsignarTerminal(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "asignar_usuario_terminal" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("ID_TERMINAL", c.Id_Terminal);
            operation.AddVarcharParam("ID_USUARIO", c.Identificacion);

            return operation;
        }
        public SqlOperation ActualizarClave(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_usuario_clave" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("IDENTIFICACION", c.Identificacion);
            operation.AddVarcharParam("CLAVE", c.Clave);

            return operation;
        }
        public SqlOperation ActualizarFoto(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "update_usuario_foto" };

            var c = (Usuario)entity;
            operation.AddVarcharParam("IDENTIFICACION", c.Identificacion);
            operation.AddVarcharParam("FOTO", c.Foto);

            return operation;
        }
        public SqlOperation GetRetrieveAllByRol(BaseEntity entity)
        {
            var ProcedureName = "list_usuario_by_rol";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Usuario)entity;
            operation.AddVarcharParam("ID_ROL", c.Id_Rol);

            return operation;
        }
        public SqlOperation GetRetrieveAllByTerminalOrEmpresa(BaseEntity entity)
        {
            var ProcedureName = "list_usuario_by_terminal_or_empresa";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            var c = (Usuario)entity;

            if (c.Id_Terminal == null)
            {
                operation.AddNullParam("ID_TERMINAL", SqlDbType.VarChar);
            }
            else
            {
                operation.AddVarcharParam("ID_TERMINAL", c.Id_Terminal);
            }

            if (c.Id_Empresa_Bus == null)
            {
                operation.AddNullParam("ID_EMPRESA", SqlDbType.VarChar);
            }
            else
            {
                operation.AddVarcharParam("ID_EMPRESA", c.Id_Empresa_Bus);
            }


            return operation;
        }

        public SqlOperation GetRetrieveByRol(Usuario entity)
        {
            var ProcedureName = "select_usuario_by_rol";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            operation.AddVarcharParam("ID_ROL", entity.Id_Rol); // el ID_ROL tiene que ser un int
            operation.AddVarcharParam("IDENTIFICACION", entity.Identificacion);

            return operation;
        }

        // >>=========================================================================<<
        //                             >> Custom Mappers <<
        // >>=========================================================================<<
        // >> Multiple
        // >> Single
    }
}
