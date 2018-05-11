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
    public class ListManager : BaseManager, ICoreManager<ListValue>
    {
        // >> CRUD Factory
        private ListValueCrudFactory crudListValue;
        // >> Constructor
        public ListManager()
        {
            crudListValue = new ListValueCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public ListValue Create(ListValue listValue)
        {
            try
            {
                var dbUser = crudListValue.Retrieve(listValue);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(listValue, new string[] { });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return listValue = crudListValue.Create(listValue);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public ListValue RetrieveById(ListValue listValue)
        {
            try
            {
                listValue = crudListValue.Retrieve(listValue);

                return listValue;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<ListValue> RetrieveAll()
        {
            try
            {
                var listValues = crudListValue.RetrieveAll();
                return listValues;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public ListValue Update(ListValue listValue)
        {
            try
            {
                var dbUser = crudListValue.Retrieve(listValue);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // TODO
                // Omit nullable properties
                var missingFields = CheckMissingFields(listValue, new string[] { "Id_Empresa_Bus", "Id_Terminal" });
                missingFields.ForEach(missing =>
                {
                    listValue[missing] = dbUser[missing];
                });

                return listValue = crudListValue.Update(listValue);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(ListValue listValue)
        {
            try
            {
                var dbUser = crudListValue.Retrieve(listValue);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudListValue.Delete(listValue);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> List By Id Lista
        public List<ListValue> RetrieveAllByIdLista(ListValue listValue)
        {
            try
            {
                var listValues = crudListValue.RetrieveAllByIdLista(listValue);
                return listValues;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
