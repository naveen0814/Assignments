using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;

namespace TechShop.dao
{
    public interface IOrderRepository
    {
        bool CreateOrder(Order order, List<OrderDetail> orderDetails);
        List<Order> GetOrdersByCustomerId(int customerId);
        Order GetOrderById(int orderId);
    }
}