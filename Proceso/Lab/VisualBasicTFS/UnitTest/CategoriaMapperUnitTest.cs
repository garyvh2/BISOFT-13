using AccesoDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace UnitTest
{
    public class CategoriaMapperUnitTest
    {
        CategoriaMapper _CategoriaMapper = new CategoriaMapper();

        [Fact]
        public void CrearCategoria ()
        {
            Categoria CrearCategoria = new Categoria();
            Boolean result = _CategoriaMapper.insert(CrearCategoria);

            Assert.True(result, "Categoria no fue creada");
        }
    }
}
