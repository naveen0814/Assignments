using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;
using TechShop.exception;
using TechShop.util;

namespace TechShop.dao
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly IInventoryRepository inventoryRepo = new InventoryRepositoryImpl();

        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();

            try
            {
                // Step 1: Insert Order
                string orderQuery = "INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, Status) " +
                                    "VALUES (@oid, @cid, @date, @total, @status)";
                SqlCommand cmdOrder = new SqlCommand(orderQuery, conn, tx);
                cmdOrder.Parameters.AddWithValue("@oid", order.OrderID);
                cmdOrder.Parameters.AddWithValue("@cid", order.Customer.CustomerID);
                cmdOrder.Parameters.AddWithValue("@date", order.OrderDate);
                cmdOrder.Parameters.AddWithValue("@total", order.TotalAmount);
                cmdOrder.Parameters.AddWithValue("@status", order.Status);
                cmdOrder.ExecuteNonQuery();

                // Step 2: Insert OrderDetails and update inventory
                foreach (var detail in orderDetails)
                {
                    Inventory inventory = inventoryRepo.GetInventoryByProductId(detail.Product.ProductID);
                    if (inventory == null || inventory.QuantityInStock < detail.Quantity)
                        throw new InsufficientStockException($"Insufficient stock for {detail.Product.ProductName}");

                    // Insert OrderDetail
                    string detailQuery = "INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) " +
                                         "VALUES (@odid, @oid, @pid, @qty)";
                    SqlCommand cmdDetail = new SqlCommand(detailQuery, conn, tx);
                    cmdDetail.Parameters.AddWithValue("@odid", detail.OrderDetailID);
                    cmdDetail.Parameters.AddWithValue("@oid", order.OrderID);
                    cmdDetail.Parameters.AddWithValue("@pid", detail.Product.ProductID);
                    cmdDetail.Parameters.AddWithValue("@qty", detail.Quantity);
                    cmdDetail.ExecuteNonQuery();

                    // Update inventory
                    int newStock = inventory.QuantityInStock - detail.Quantity;
                    inventoryRepo.UpdateInventory(detail.Product.ProductID, newStock);
                }

                tx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("❌ Order creation failed: " + ex.Message);
                return false;
            }
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "SELECT * FROM Orders WHERE CustomerID = @cid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cid", customerId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderID = reader["OrderID"] != DBNull.Value ? (int)reader["OrderID"] : 0,
                    OrderDate = reader["OrderDate"] != DBNull.Value ? (DateTime)reader["OrderDate"] : DateTime.MinValue,
                    TotalAmount = reader["TotalAmount"] != DBNull.Value ? (decimal)reader["TotalAmount"] : 0,
                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Unknown"
                });
            }
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            using SqlConnection conn = DBConnUtil.GetConnection();
            string query = "SELECT * FROM Orders WHERE OrderID = @oid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@oid", orderId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Order
                {
                    OrderID = reader["OrderID"] != DBNull.Value ? (int)reader["OrderID"] : 0,
                    OrderDate = reader["OrderDate"] != DBNull.Value ? (DateTime)reader["OrderDate"] : DateTime.MinValue,
                    TotalAmount = reader["TotalAmount"] != DBNull.Value ? (decimal)reader["TotalAmount"] : 0,
                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Unknown"
                };
            }
            return null;
        }
    }
}