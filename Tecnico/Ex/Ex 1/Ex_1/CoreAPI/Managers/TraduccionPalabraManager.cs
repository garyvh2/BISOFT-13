using AccesoDatos.CRUD;
using Entidades.Classes;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    public class TraduccionPalabraManager : BaseManager
    {
        // >> CRUD Factory
        private TraduccionPalabraCrudFactory crudTraduccionPalabra;
        // >> Constructor
        public TraduccionPalabraManager()
        {
            crudTraduccionPalabra = new TraduccionPalabraCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public void Create(TraduccionPalabra traduccionPalabra)
        {
            try
            {
                var missingFields = CheckMissingFields(traduccionPalabra, new string[] { "Id" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                crudTraduccionPalabra.Create(traduccionPalabra);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
