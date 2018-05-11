using CoreAPI.Integrations;
using CoreAPI.Integrations.Models;
using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.CRUD.ArchitectureComponents;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using Entities.Entities.ArchitectureEntities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers.ArchitectureComponents
{
    public class ConfigurationManager : BaseManager, ICoreManager<ConfigurationItem>
    {
        // >> CRUD Factory
        private ConfigurationItemCrudFactory crudConfigurationItem;
        // >> Constructor
        public ConfigurationManager()
        {
            crudConfigurationItem = new ConfigurationItemCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public ConfigurationItem Create(ConfigurationItem configurationItem)
        {
            try
            {
                var dbUser = crudConfigurationItem.Retrieve(configurationItem);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(configurationItem, new string[] { });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return configurationItem = crudConfigurationItem.Create(configurationItem);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public ConfigurationItem RetrieveById(ConfigurationItem configurationItem)
        {
            try
            {
                configurationItem = crudConfigurationItem.Retrieve(configurationItem);

                return configurationItem;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<ConfigurationItem> RetrieveAll()
        {
            try
            {
                var configurationItems = crudConfigurationItem.RetrieveAll();
                return configurationItems;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public ConfigurationItem Update(ConfigurationItem configurationItem)
        {
            try
            {
                var dbUser = crudConfigurationItem.Retrieve(configurationItem);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // TODO
                // Omit nullable properties
                var missingFields = CheckMissingFields(configurationItem, new string[] { "Id_Empresa_Bus", "Id_Terminal" });
                missingFields.ForEach(missing =>
                {
                    configurationItem[missing] = dbUser[missing];
                });

                return configurationItem = crudConfigurationItem.Update(configurationItem);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(ConfigurationItem configurationItem)
        {
            try
            {
                var dbUser = crudConfigurationItem.Retrieve(configurationItem);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudConfigurationItem.Delete(configurationItem);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
    }
}
