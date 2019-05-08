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

        [TestMethod()]
        public void ConvertMetersToInches()
        {
            var expected = 78.74;

            var actual = 2 * Product.InchesPerMeter;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void MinimumPriceTest()
        {
            var currentProduct = new Product();
            var expected = .96m;

            var actual = currentProduct.MinimumPrice;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTestBulk()
        {
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;

            var actual = currentProduct.MinimumPrice;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer  ";

            var expected = "Steel Hammer";

            var actual = currentProduct.ProductName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Length()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";

            string expected = "Saw";
            string expectedMessage = null;

            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void Category_newValue()
        {
            var currentProduct = new Product();
            currentProduct.Category = "Garden";

            var expected = "Garden";

            var actual = currentProduct.Category;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_DefaultValue()
        {
            var currentProduct = new Product();

            var expected = 1;

            var actual = currentProduct.SequenceNumber;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_NewValue()
        {
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;

            var expected = 5;

            var actual = currentProduct.SequenceNumber;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            var currentProduct = new Product();

            var expected = "Tools-1";

            var actual = currentProduct.ProductCode;

            Assert.AreEqual(expected, actual);
        }
    }

}