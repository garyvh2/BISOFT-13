using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class BaseManager
    {
        public static List<string> CheckMissingFields(Object objeto, String[] omit)
        {
            // >> Lista de campos faltantes
            List<string> missingFields = new List<string>();

            // >> Revisar si la instancia del objeto es valida
            if (Object.ReferenceEquals(null, objeto))
                return missingFields;

            // >> Obtener las propiedades del objeto
            var properties = objeto.GetType().GetProperties(
              BindingFlags.Instance |
              BindingFlags.Static |
              BindingFlags.Public |
              BindingFlags.NonPublic);

            // >> Recorrido por ada propiedad
            foreach (var prop in properties)
            {
                // >> Omitir Write-Only Properties 
                if (!prop.CanRead)
                {
                    continue;
                }
                // >> Omitir Metodo Especial de extraccion de propiedades y ID en casos necesarios
                else if (prop.Name == "Item" || (omit.Contains(prop.Name)))
                {
                    continue;
                }
                // >> Omitir Propiedades cuyo valor no puede ser nulo
                else if (prop.PropertyType.IsValueType)
                {
                    switch (prop.GetValue(prop.GetGetMethod().IsStatic ? null : objeto))
                    {
                        case DateTime dateValue:
                            if (dateValue == DateTime.MinValue)
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
