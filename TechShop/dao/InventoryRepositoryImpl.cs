using System;
using Microsoft.Data.SqlClient;
using TechShop.entity;
using TechShop.util;

namespace TechShop.dao
{
    public class InventoryRepositoryImpl : IInventoryRepository
    {
        public Inventory GetInventoryByProductId(int productId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "SELECT * FROM Inventory WHERE ProductID = @pid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pid", productId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Inventory
                {
                    InventoryID = (int)reader["InventoryID"],
                    QuantityInStock = (int)reader["QuantityInStock"],
                    LastStockUpdate = (DateTime)reader["LastStockUpdate"],
                    Product = new ProductRepositoryImpl().GetProductById(productId)
                };
            }
            return null;
        }

        public bool UpdateInventory(int productId, int newQuantity)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "UPDATE Inventory SET QuantityInStock = @qty, LastStockUpdate = GETDATE() WHERE ProductID = @pid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@qty", newQuantity);
            cmd.Parameters.AddWithValue("@pid", productId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
