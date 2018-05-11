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
    public class RequisitoBusMapper : BaseMapper<RequisitoBus>, ISqlStaments, IObjectMapper
    {
        public SqlOperation modificarEstadoRequisito(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "modificarEstado" };

            var c = (RequisitoBus)entity;
            operation.AddIntParam("ID_REQUISITO_BUS", c.ID_REQUISITO_BUS);
            operation.AddVarcharParam("ESTADO", c.ESTADO);
            return operation;
        }

        public virtual SqlOperation listar()
        {
            var ProcedureName = "listar_requisitos_bus";
            var operation = new SqlOperation { ProcedureName = ProcedureName };
            return operation;
        }

        public SqlOperation ELIMINAR(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "delete_REQUISITO_BUS" };

            var c = (RequisitoBus)entity;
            operation.AddIntParam("ID_REQUISITO", c.ID_REQUISITO);
            operation.AddVarcharParam("ID_BUS", c.ID_BUS);
            return operation;
        }
    }
}
