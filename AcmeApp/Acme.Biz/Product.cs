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
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        public decimal Cost { get; set; }

        public decimal CalculatateSuggestedPrice(decimal markupPercentage) => this.Cost + (this.Cost * markupPercentage / 100);
        

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public Product()
        {
            Console.WriteLine("Product instance created");
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }
        public Product(int productId,
                       string productName,
                       string description) : this()
        {
            this.ProductID = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }


            Console.WriteLine($"Product instance has a name: {ProductName}");
        }

        private string productName;

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
                productName = value; }
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

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 001;
        public string ValidationMessage { get; private set;}
        public string ProductCode => $"{this.Category}-{this.SequenceNumber:00}";


        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("This is the new email message");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New product", this.ProductName, "sales@abc.com");

            var result = LoggingService.LogAction("Hello hello from logging");

            return $"Hello {ProductName} ({ProductID}): {Description} Available on:{AvailabilityDate?.ToShortDateString()}";
        }

        public override string ToString() => $"{this.ProductName} {this.productID} ";

   }
}
