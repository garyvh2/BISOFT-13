using AccesoDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ProductoManager : BaseManager
    {
        private ProductoCrudFactory crudProducto;

        public ProductoManager()
        {
            crudProducto = new ProductoCrudFactory();
        }

        public void Create(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> RetrieveAll()
        {
            return crudProducto.RetrieveAll<Producto>();
        }

        public Producto RetrieveById(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void Update(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void Delete(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
