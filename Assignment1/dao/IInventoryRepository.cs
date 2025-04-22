using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;

namespace TechShop.dao
{
    public interface IInventoryRepository
    {
        Inventory GetInventoryByProductId(int productId);
        bool UpdateInventory(int productId, int newQuantity);
    }
}