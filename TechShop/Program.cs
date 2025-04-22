using System;
using System.Collections.Generic;
using System.Linq;
using TechShop.dao;
using TechShop.entity;

namespace TechShop
{
    class MainModule
    {
        static void Main(string[] args)
        {
            ICustomerRepository customerRepo = new CustomerRepositoryImpl();
            IProductRepository productRepo = new ProductRepositoryImpl();
            IInventoryRepository inventoryRepo = new InventoryRepositoryImpl();
            IOrderRepository orderRepo = new OrderRepositoryImpl();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========== TECHSHOP MENU ===========");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Manage Product Catalog");
                Console.WriteLine("3. Place Customer Order");
                Console.WriteLine("4. Track Order Status");
                Console.WriteLine("5. Inventory Management");
                Console.WriteLine("6. View Sales Report");
                Console.WriteLine("7. Update Customer Account Info");
                Console.WriteLine("8. Process Payment (Simulated)");
                Console.WriteLine("9. Search Products & Recommendations");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": // Register Customer
                            Customer cust = new Customer();
                            Console.Write("Enter Customer ID: ");
                            cust.CustomerID = int.Parse(Console.ReadLine());
                            Console.Write("First Name: ");
                            cust.FirstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            cust.LastName = Console.ReadLine();
                            Console.Write("Email: ");
                            cust.Email = Console.ReadLine();
                            Console.Write("Phone: ");
                            cust.Phone = Console.ReadLine();
                            Console.Write("Address: ");
                            cust.Address = Console.ReadLine();

                            var existing = customerRepo.GetAllCustomers().FirstOrDefault(c => c.Email == cust.Email);
                            if (existing != null)
                            {
                                Console.WriteLine("Duplicate email. Registration failed.");
                            }
                            else
                            {
                                Console.WriteLine(customerRepo.AddCustomer(cust)
                                    ? " Customer registered."
                                    : " Registration failed.");
                            }
                            break;

                        case "2": // Product Catalog Management
                            Console.WriteLine("1. Add Product\n2. Update Product");
                            string subChoice = Console.ReadLine();
                            if (subChoice == "1")
                            {
                                Product prod = new Product();
                                Console.Write("Product ID: ");
                                prod.ProductID = int.Parse(Console.ReadLine());
                                Console.Write("Name: ");
                                prod.ProductName = Console.ReadLine();
                                Console.Write("Description: ");
                                prod.Description = Console.ReadLine();
                                Console.Write("Price: ");
                                prod.Price = decimal.Parse(Console.ReadLine());
                                Console.WriteLine(productRepo.AddProduct(prod) ? " Product added." : " Failed.");
                            }
                            else if (subChoice == "2")
                            {
                                Console.Write("Enter Product ID to update: ");
                                int pid = int.Parse(Console.ReadLine());
                                var product = productRepo.GetProductById(pid);
                                if (product != null)
                                {
                                    Console.Write("New Description: ");
                                    product.Description = Console.ReadLine();
                                    Console.Write("New Price: ");
                                    product.Price = decimal.Parse(Console.ReadLine());
                                    Console.WriteLine(productRepo.UpdateProduct(product)
                                        ? " Product updated." : " Update failed.");
                                }
                                else Console.WriteLine(" Product not found.");
                            }
                            break;

                        case "3": // Place Order
                            Console.Write("Order ID: ");
                            int orderId = int.Parse(Console.ReadLine());
                            Console.Write("Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            var customer = customerRepo.GetCustomerById(customerId);
                            if (customer == null) { Console.WriteLine(" Customer not found."); break; }

                            List<OrderDetail> details = new List<OrderDetail>();
                            decimal total = 0;
                            while (true)
                            {
                                Console.Write("Product ID (0 to finish): ");
                                int pid = int.Parse(Console.ReadLine());
                                if (pid == 0) break;

                                var p = productRepo.GetProductById(pid);
                                if (p == null) { Console.WriteLine(" Not found."); continue; }

                                Console.Write("Quantity: ");
                                int qty = int.Parse(Console.ReadLine());

                                details.Add(new OrderDetail
                                {
                                    OrderDetailID = new Random().Next(1000, 9999),
                                    Product = p,
                                    Quantity = qty
                                });
                                total += qty * p.Price;
                            }

                            var order = new Order
                            {
                                OrderID = orderId,
                                Customer = customer,
                                OrderDate = DateTime.Now,
                                TotalAmount = total,
                                Status = "Processing"
                            };

                            Console.WriteLine(orderRepo.CreateOrder(order, details)
                                ? " Order placed!" : " Order failed.");
                            break;

                        case "4": // Track Order Status
                            Console.Write("Enter Customer ID: ");
                            int cid = int.Parse(Console.ReadLine());
                            var orders = orderRepo.GetOrdersByCustomerId(cid);
                            if (orders.Count == 0)
                                Console.WriteLine(" No orders.");
                            else
                                orders.ForEach(o =>
                                    Console.WriteLine($" Order #{o.OrderID} - {o.TotalAmount} - {o.Status}"));
                            break;

                        case "5": // Inventory Management
                            Console.Write("Enter low-stock threshold: ");
                            int threshold = int.Parse(Console.ReadLine());
                            var lowStock = productRepo.GetAllProducts()
                                .Where(p =>
                                {
                                    var inv = inventoryRepo.GetInventoryByProductId(p.ProductID);
                                    return inv != null && inv.QuantityInStock <= threshold;
                                });
                            Console.WriteLine("Low Stock Products:");
                            foreach (var p in lowStock) p.GetProductDetails();
                            break;

                        case "6": // Sales Report
                            var products = productRepo.GetAllProducts();
                            decimal totalSales = 0;
                            Dictionary<string, decimal> productSales = new();

                            foreach (var prodItem in products)
                            {
                                var inv = inventoryRepo.GetInventoryByProductId(prodItem.ProductID);
                                int soldQty = inv != null ? 100 - inv.QuantityInStock : 0;
                                decimal revenue = soldQty * prodItem.Price;
                                totalSales += revenue;
                                productSales[prodItem.ProductName] = revenue;
                            }

                            Console.WriteLine($"Total Sales: {totalSales}");
                            var top = productSales.OrderByDescending(p => p.Value).FirstOrDefault();
                            Console.WriteLine($"Top Product: {top.Key} - {top.Value}");
                            break;

                        case "7": // Customer Account Update
                            Console.Write("Enter Customer ID to update: ");
                            int upid = int.Parse(Console.ReadLine());
                            var toUpdate = customerRepo.GetCustomerById(upid);
                            if (toUpdate != null)
                            {
                                Console.Write("New Email: ");
                                string newEmail = Console.ReadLine();
                                Console.Write("New Phone: ");
                                string newPhone = Console.ReadLine();
                                Console.Write("New Address: ");
                                string newAddr = Console.ReadLine();
                                toUpdate.UpdateCustomerInfo(newEmail, newPhone, newAddr);
                                Console.WriteLine(customerRepo.UpdateCustomer(toUpdate)
                                    ? "Updated." : "Failed.");
                            }
                            else Console.WriteLine("Customer not found.");
                            break;

                        case "8": // Payment Processing (Simulated)
                            Console.Write("Enter Order ID to simulate payment: ");
                            int payId = int.Parse(Console.ReadLine());
                            var paidOrder = orderRepo.GetOrderById(payId);
                            if (paidOrder != null)
                            {
                                paidOrder.Status = "Paid";
                                Console.WriteLine("Payment recorded successfully (simulation).");
                            }
                            else Console.WriteLine("Order not found.");
                            break;

                        case "9": // Product Search & Recommendations
                            Console.Write("Enter keyword: ");
                            string key = Console.ReadLine();
                            var found = productRepo.SearchProductsByName(key);
                            if (found.Count == 0)
                                Console.WriteLine("No products.");
                            else
                                found.ForEach(p => p.GetProductDetails());
                            break;

                        case "0":
                            exit = true;
                            Console.WriteLine("Thank you for using TechShop!");
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
