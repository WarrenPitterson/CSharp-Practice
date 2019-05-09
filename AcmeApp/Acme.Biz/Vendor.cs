using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class Vendor
    {

        public OperationResult PlaceOrder(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;

            var orderText = $"Order from Acme, Inc" + System.Environment.NewLine + "Product:" + product.ProductCode + System.Environment.NewLine + "Quantity:" + quantity;

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResutlt = new OperationResult(success, orderText);

            return operationResutlt;
        }
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy, string instructions)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderText = $"order from Acme, Inc" + System.Environment.NewLine + "Product:" +
                product.ProductCode + System.Environment.NewLine + "Quantity:" + quantity;

            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine + "Deliver By:" + deliverBy.Value.ToString("d");
            }
            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += System.Environment.NewLine + "Instructions:" + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResutlt = new OperationResult(success, orderText);

            return operationResutlt;
        }

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }
    }
}
