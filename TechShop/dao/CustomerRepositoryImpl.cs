using System;
using System.Collections.Generic;
using TechShop.entity;
using Microsoft.Data.SqlClient;
using TechShop.util;

namespace TechShop.dao
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address) " +
                               "VALUES (@id, @first, @last, @email, @phone, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                cmd.Parameters.AddWithValue("@first", customer.FirstName);
                cmd.Parameters.AddWithValue("@last", customer.LastName);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);
                cmd.Parameters.AddWithValue("@address", customer.Address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "UPDATE Customers SET Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
                return null;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Customers";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return customers;
        }
    }
}