using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void GetProductDetails()
        {
            Console.WriteLine($"Product: {ProductName}, Price: {Price}, Description: {Description}");
        }

        public void UpdateProductInfo(string desc, decimal price)
        {
            Description = desc;
            if (price >= 0) Price = price;
        }

        public bool IsProductInStock(int quantity, int available)
        {
            return available >= quantity;
        }
    }
}