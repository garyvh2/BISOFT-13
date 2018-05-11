using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Classes
{
    // >> Project Base Entity (CRUD)
    public class BaseEntity
    {
        public BaseEntity()
        {

        }
        // >> Property Retriever
        public object this[string propertyName]
        {
            get {
                return this.GetType().GetProperty(propertyName).GetValue(this, null);
            }
            set {
                this.GetType().GetProperty(propertyName).SetValue(this, value, null);
            }
        }
    }
}
