using Entities.Classes;
using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    public class BaseManager
    {
        // >> Revision de campos faltantes
        public static List<string> CheckMissingFields(BaseEntity objeto, String[] omit = null, String[] only = null, String[] force = null)
        {
            omit = omit == null ? new String[0] : omit;
            only = only == null ? new String[0] : only;
            force = force == null ? new String[0] : force;
            // >> Lista de campos faltantes
            List<string> missingFields = new List<string>();

            // >> Revisar si la instancia del objeto es valida
            if (Object.ReferenceEquals(null, objeto))
                return missingFields;

            // >> Obtener las propiedades del objeto
            //var properties = objeto.GetType().GetProperties(
            //  BindingFlags.Instance |
            //  BindingFlags.Static |
            //  BindingFlags.Public |
            //  BindingFlags.NonPublic);

            var properties = objeto.GetLiteralProperties<IsEntityProperty>();


            // >> Recorrido por ada propiedad
            foreach (var prop in properties)
            {
                var only_retrieve = objeto.GetPropertyAttributeValue<IsEntityProperty, bool>("OnlyRetrieve", prop.Name);

                // >> Omitir Write-Only Properties 
                if (!prop.CanRead || only_retrieve)
                {
                    continue;
                }
                // It's nullable
                if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                {
                    var val = prop.GetValue(prop.GetGetMethod().IsStatic ? null : objeto);
                    if (val == null && (!(force.Contains(prop.Name)))) {
                        continue;
                    } else if (val == null && (force.Contains(prop.Name)))
                    {
                        missingFields.Add(prop.Name);
                        continue;
                    }
                }
                // >> Omitir Metodo Especial de extraccion de propiedades y ID en casos necesarios
                else if (prop.Name == "Item" || (omit.Contains(prop.Name)) || (!(only.Contains(prop.Name)) && only.Length > 0))
                {
                    continue;
                }
                // >> Omitir Propiedades cuyo valor no puede ser nulo
                else if (prop.PropertyType.IsValueType)
                {
                    switch (prop.GetValue(prop.GetGetMethod().IsStatic ? null : objeto))
                    {
                        case DateTime dateValue:
                            if (dateValue == DateTime.MinValue || dateValue == default(DateTime) || dateValue == null)
                                missingFields.Add(prop.Name);
                            break;
                        case int intValue:
                            if (intValue == 0)
                                missingFields.Add(prop.Name);
                            break;
                        default:
                            continue;
                    }
                }
                // >> Obtener el valor de la pripiedad
                Object value = prop.GetValue(prop.GetGetMethod().IsStatic ? null : objeto);
                // >> Si el valor es null, entonces se registra como faltante
                if (Object.ReferenceEquals(null, value))
                {
                    missingFields.Add(prop.Name);
                    continue;
                }
                // >> Verificar si el valor es un string vacio
                String str = value as String;
                if (null != str)
                    if (str.Equals(""))
                    {
                        missingFields.Add(prop.Name);
                        continue;
                    }
            }

            return missingFields;
        }
    }
}
