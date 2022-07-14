
﻿using System;
﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public void InsertOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
