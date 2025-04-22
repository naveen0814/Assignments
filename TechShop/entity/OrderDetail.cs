using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Order Order { get; set; }     // Composition
        public Product Product { get; set; } // Composition
        public int Quantity { get; set; }

        public decimal CalculateSubtotal()
        {
            return Quantity * Product.Price;
        }

        public void UpdateQuantity(int newQty)
        {
            if (newQty > 0)
                Quantity = newQty;
        }

        public void GetOrderDetailInfo()
        {
            Console.WriteLine($"Product: {Product.ProductName}, Quantity: {Quantity}, Subtotal: {CalculateSubtotal()}");
        }
    }
}