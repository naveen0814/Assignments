using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; } // Composition
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}, Customer: {Customer.FirstName} {Customer.LastName}, Total: {TotalAmount}, Status: {Status}");
        }

        public void UpdateOrderStatus(string newStatus)
        {
            Status = newStatus;
        }
    }
}