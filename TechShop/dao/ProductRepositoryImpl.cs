using System;
using System.Collections.Generic;
using TechShop.entity;
using Microsoft.Data.SqlClient;
using TechShop.util;

namespace TechShop.dao
{
    public class ProductRepositoryImpl : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "INSERT INTO Products (ProductID, ProductName, Description, Price) VALUES (@id, @name, @desc, @price)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", product.ProductID);
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@desc", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "UPDATE Products SET Description = @desc, Price = @price WHERE ProductID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@desc", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@id", product.ProductID);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public Product GetProductById(int productId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "SELECT * FROM Products WHERE ProductID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", productId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = reader["ProductName"].ToString(),
                    Description = reader["Description"].ToString(),
                    Price = (decimal)reader["Price"]
                };
            }
            return null;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = reader["ProductName"].ToString(),
                    Description = reader["Description"].ToString(),
                    Price = (decimal)reader["Price"]
                });
            }
            return list;
        }

        public List<Product> SearchProductsByName(string keyword)
        {
            List<Product> matches = new List<Product>();
            foreach (var p in GetAllProducts())
            {
                if (p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    matches.Add(p);
            }
            return matches;
        }
    }
}