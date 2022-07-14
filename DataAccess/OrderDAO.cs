using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class OrderDAO
    {

        private static OrderDAO instance = null;
        private static readonly object instanceLock = null;
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> order = null;
            using var db = new FStoreDBAssignmentContext();
            order = db.Order.ToList();
            return order;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            using var db = new FStoreDBAssignmentContext();
            order = db.Order.SingleOrDefault(x => x.OrderId == id);
            return order;
        }

        public void AddOrder(Order order)
        {
            using var db = new FStoreDBAssignmentContext();
            Order order1 = GetOrderById(order.OrderId);
            if (order1 != null)
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("product already exsit");
            }
        }
        public void UpdateOrder(Order order)
        {
            using var db = new FStoreDBAssignmentContext();
            Order order1 = GetOrderById(order.OrderId);
            if (order1 != null)
            {
                db.Order.Update(order);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("product already exsit");
            }
        }
        public void DeleteOrder(Order order)
        {
            using var db = new FStoreDBAssignmentContext();
            Order order1 = GetOrderById(order.OrderId);
            if (order1 != null)
            {
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
