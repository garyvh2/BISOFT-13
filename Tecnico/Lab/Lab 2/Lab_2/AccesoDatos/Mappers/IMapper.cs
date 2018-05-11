using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mappers
{
    interface IMapper<T>
    {
        // Create
        void insert(T obj);

        // Read
        T findById(int id);
        List<T> findAll();

        // Update
        void update(T obj);

        // Delete
        void delete(T obj);

        // Map
        T MapperSingle(SqlDataReader sqlDataReader);
        List<T> MapperMultiple(SqlDataReader sqlDataReader);
    }
}
