using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuplidoresBlazor.BLL;
using SuplidoresBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuplidoresB
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void BuscarTest()
        {
            var paso = ProductosBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Productos>();
            lista = ProductosBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}