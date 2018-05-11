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
    public class RequisitosMapper : BaseMapper<Requisitos>, ISqlStaments, IObjectMapper
    {
        public SqlOperation ListarRequisito()
        {
            var ProcedureName = "list_requisito";
            var operation = new SqlOperation { ProcedureName = ProcedureName };

            return operation;

        }
    }
}
