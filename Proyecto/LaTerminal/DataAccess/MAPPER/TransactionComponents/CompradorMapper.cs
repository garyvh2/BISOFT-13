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
    public class CompradorMapper : BaseMapper<Comprador>, ISqlStaments, IObjectMapper
    {
        // >> Parametros de objeto

        // >> Parametros de consulta
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 

        // >>=========================================================================<<
        //                             >> Object Mappers <<
        // >>=========================================================================<<
        // >> Multiple
    }
}