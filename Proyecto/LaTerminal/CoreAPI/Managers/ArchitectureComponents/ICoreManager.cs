using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers.ArchitectureComponents
{
    public interface ICoreManager<T>
    {
        T Create(T obj);
        T RetrieveById(T obj);
        List<T> RetrieveAll();
        T Update(T obj);
        void Delete(T obj);
    }
}
