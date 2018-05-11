using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.ArchitectureEntities
{
    // >> IsEntityProperty
    // >> Su proposito es determinar si la propiedad encontrada en una clase
    // >> pertenece al modelo de datos del objeto
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsEntityProperty : BaseAttribute
    {
        public bool IsNullable { get; set; }
        public bool OnlyRetrieve { get; set; }
        public IsEntityProperty(bool IsNullable = false, bool OnlyRetrieve = false)
        {
            this.IsNullable = IsNullable;
            this.OnlyRetrieve = OnlyRetrieve;
        }
    }
    // >> IsIdentity
    // >> Su proposito es determinar la propiedad que se manifiesta como identity
    // >> en un modelo de datos, el attributo 'IncludeMapper' identifica si este
    // >> debe incluirse en la creacion de datos, en casos de entidades auto incrementales
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsIdentity : BaseAttribute
    {
        public bool IncludeMapper { get; set; }
        public IsIdentity(bool IsIdentity = true)
        {
            this.IncludeMapper = IsIdentity;
        }
    }
    // >> DBTable
    // >> Su proposito es addicionar informacion escencial a una clase respecto a la
    // >> tabla equivalente en la base de datos, en caso de ser necesario. Posee la
    // >> propiedad 'name' que identifica el nombre de la tabla 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DBTable : BaseAttribute
    {
        public string name { get; set; }
        public DBTable(string name = "")
        {
            this.name = name;
        }
    }
}
