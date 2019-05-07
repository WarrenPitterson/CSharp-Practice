using Acme.Common;
using System;
using static Acme.Common.LoggingService;
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
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

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

        private Vendor productvendor;

        public Vendor ProductVendor
        {
            get
            {
                if (ProductVendor == null)
                {
                    productvendor = new Vendor();
                }
                return productvendor;
            }
            set { productvendor = value; }
        }


        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("This is the new email message");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New product", this.ProductName, "sales@abc.com");

            var resutlt = LoggingService.LogAction("Hello hello from logging");

            return $"Hello {ProductName} ({ProductID}): {Description} available on {AvailabilityDate}";
        }
    }
}
