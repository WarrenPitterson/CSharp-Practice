using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange 
            var currentProduct = new Product
            {
                ProductName = "Saw",
                ProductID = 1,
                Description = "15 inch steel blade hand saw",
            };

            currentProduct.ProductVendor.CompanyName = "ABC Company";

            var expected = "Hello Saw (1): 15 inch steel blade hand saw";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SayHello_ParameterisedConstructor()
        {
            //Arrange 
            var currentProduct = new Product(1, "Saw", "15 inch steel blade hand saw");

            var expected = "Hello Saw (1): 15 inch steel blade hand saw";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_null()
        {
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            var actual = companyName;

            Assert.AreEqual(expected, actual);

        }
    }
}