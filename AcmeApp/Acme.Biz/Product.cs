using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages product carried in inventory
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
        }
        public Product(int productId, 
                       string productName, 
                       string description) : this()
        {
            this.ProductID = productId;
            this.ProductName = productName;
            this.Description = description;
            

            Console.WriteLine($"Product instance has a name: {ProductName}");
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string SayHello()
        {
            return $"Hello {ProductName} ({ProductID}): {Description}";
        }
    }
}
