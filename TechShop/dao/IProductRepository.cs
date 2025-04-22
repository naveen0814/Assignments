using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;

namespace TechShop.dao
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
        List<Product> SearchProductsByName(string keyword);
    }
}