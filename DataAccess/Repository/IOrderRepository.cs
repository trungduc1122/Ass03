using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);

        public void DeleteOrder(int orderId);
        public void InsertOrder(Order order);

        public void DeleteOrder(Order order);

    }
}
