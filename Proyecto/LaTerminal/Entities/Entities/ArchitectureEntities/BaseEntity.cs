using Entities.Entities.ArchitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    public class BaseEntity
    {
        public string Agrupar { get; set; } = "";
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Metodo de extraccion de datos por nombre de propiedad
        // USO:
        //      obj["ID"];      - retorna el valor del ID en el objeto
        //      obj["ID"] = 1   - asigna un valor al ID del objeto 
        //
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
        // >> Metodo de extraccion propiedades con attributos con valor equivalente al brindado
        // USO:
        //      obj.GetPropertiesWithAttributeEquals<IsEntityProperty, bool>("IsEntity", true)
        //      Este recorrera las propiedades del objeto brindado en buqueda del custom attribute brindado
        //      con el nombre "IsEntity" los cuales deben tener el valor true
        //
        public T GetClassAttributeValue<A, T>(string name) where T : IComparable where A : BaseAttribute
        {
            T value = default(T);
            // >> Se extraen los attributos personalizados
            var attributes = (A[])this.GetType().GetCustomAttributes(typeof(A), true);
            // >> Si la pripiedad tiene un attributo personzalizado
            if (attributes.Length > 0)
            {
                // >> Se compara si el valor enviado coincide con el valor del attributo
                value = (T)attributes[0][name];
            }

            return value;
        }

        // >> Metodo de extraccion propiedades con attributos con valor equivalente al brindado
        // USO:
        //      obj.GetPropertiesWithAttributeEquals<IsEntityProperty, bool>("IsEntity", true)
        //      Este recorrera las propiedades del objeto brindado en buqueda del custom attribute brindado
        //      con el nombre "IsEntity" los cuales deben tener el valor true
        //
        public T GetPropertyAttributeValue<A, T>(string attribute, string property) where T : IComparable where A : BaseAttribute
        {
            T value = default(T);
            // >> Se extraen las propiedades del objeto
            var properties = this.GetType().GetProperties();
            // >> Se recorre cada una
            foreach (var p in properties)
            {
                if (p.Name == property)
                {
                    // >> Se extraen los attributos personalizados
                    var attributes = (A[])p.GetCustomAttributes(typeof(A), true);
                    // >> Si la pripiedad tiene un attributo personzalizado
                    if (attributes.Length > 0)
                    {
                        // >> Se compara si el valor enviado coincide con el valor del attributo
                        value = (T)attributes[0][attribute];
                        break;
                    }
                }
            }

            return value;
        }
        // >> Metodo de extraccion propiedades con attributos con valor equivalente al brindado
        // USO:
        //      obj.GetPropertiesWithAttributeEquals<IsEntityProperty, bool>("IsEntity", true)
        //      Este recorrera las propiedades del objeto brindado en buqueda del custom attribute brindado
        //      con el nombre "IsEntity" los cuales deben tener el valor true
        //
        public List<string> GetPropertiesWithAttributeEquals<A, T>(string name, T value) where T : IComparable where A : BaseAttribute
        {
            List<string> outProp = new List<string>();
            // >> Se extraen las propiedades del objeto
            var properties = this.GetType().GetProperties();
            // >> Se recorre cada una
            foreach (var p in properties)
            {
                // >> Se extraen los attributos personalizados
                var attributes = (A[])p.GetCustomAttributes(typeof(A), true);
                // >> Si la pripiedad tiene un attributo personzalizado
                if (attributes.Length > 0)
                {
                    // >> Se compara si el valor enviado coincide con el valor del attributo
                    var attributeValue = (T)attributes[0][name];
                    if (value.CompareTo(attributeValue) == 0)
                    {
                        // >> Si son iguales se agrega a la lista
                        outProp.Add(p.Name);
                    }
                }
            }

            return outProp;
        }
        // >> Metodo de extraccion propiedades con attributos con valor equivalente al brindado
        // USO:
        //      obj.GetPropertiesWithAttribute<IsEntityProperty>();
        //      Este recorrera las propiedades y retornara las que tengan el attributo del tipo
        //      brindado
        //
        public List<string> GetPropertiesWithAttribute<A>() where A : Attribute
        {
            List<string> outProp = new List<string>();
            // >> Se extraen las propiedades del objeto
            var properties = this.GetType().GetProperties();
            // >> Se recorre cada una
            foreach (var p in properties)
            {
                // >> Se extraen los attributos personalizados
                var attributes = (A[])p.GetCustomAttributes(typeof(A), true);
                // >> Si la pripiedad tiene un attributo personzalizado
                if (attributes.Length > 0)
                {
                    // >> Se agrega a la lista
                    outProp.Add(p.Name);
                }
            }

            return outProp;
        }
        // >> Metodo de informacion de propiedades
        // USO:
        //      obj.GetLiteralProperties<IsEntityProperty>();
        //      Este recorrera las propiedades y retornara la informacion que tengan el attributo del tipo
        //      brindado
        //
        public List<PropertyInfo> GetLiteralProperties<A>() where A : Attribute
        {
            List<PropertyInfo> outProp = new List<PropertyInfo>();
            // >> Se extraen las propiedades del objeto
            var properties = this.GetType().GetProperties();
            // >> Se recorre cada una
            foreach (var p in properties)
            {
                // >> Se extraen los attributos personalizados
                var attributes = (A[])p.GetCustomAttributes(typeof(A), true);
                // >> Si la pripiedad tiene un attributo personzalizado
                if (attributes.Length > 0)
                {
                    // >> Se agrega a la lista
                    outProp.Add(p);
                }
            }

            return outProp;
        }
    }
}
