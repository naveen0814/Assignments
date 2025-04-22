using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public Product Product { get; set; } // Composition
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public int GetQuantityInStock() => QuantityInStock;

        public void AddToInventory(int qty)
        {
            QuantityInStock += qty;
            LastStockUpdate = DateTime.Now;
        }

        public void RemoveFromInventory(int qty)
        {
            if (qty <= QuantityInStock)
                QuantityInStock -= qty;
            LastStockUpdate = DateTime.Now;
        }

        public void UpdateStockQuantity(int newQty)
        {
            if (newQty >= 0)
                QuantityInStock = newQty;
            LastStockUpdate = DateTime.Now;
        }

        public bool IsProductAvailable(int qty)
        {
            return QuantityInStock >= qty;
        }

        public decimal GetInventoryValue()
        {
            return QuantityInStock * Product.Price;
        }
    }
}
