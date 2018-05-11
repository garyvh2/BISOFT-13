using DataAccess.CRUD.ArchitectureComponents;
using Entities.Entities.ArchitectureEntities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public static class ConfigurationService
    {
        // >> Singleton Return Instance
        public static T GetItem<T> (string codigo)
        {
            try
            {
                var crud = new ConfigurationItemCrudFactory();
                var item = crud.Retrieve(new ConfigurationItem()
                {
                    Codigo = codigo
                }).Valor;

                return (T)Convert.ChangeType(item, typeof(T));
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex, storeOnly: true);
                return default(T);
            }
        }
    }
}
