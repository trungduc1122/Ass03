using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    internal class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = null;
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            var orderDetail = new List<OrderDetail>();
            try
            {
                using var context = new FStoreDBAssignmentContext();
                orderDetail = context.OrderDetail.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public OrderDetail GetOrderDetailByID(int orderdetailID)
        {
            OrderDetail orderDetail = null;
            try
            {
                using var context = new FStoreDBAssignmentContext();
                orderDetail = context.OrderDetail.SingleOrDefault(o => o.OrderId == orderdetailID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }


        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByID(orderDetail.OrderId);
                if (_orderDetail == null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.OrderDetail.Add(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderdeail is alreaedy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByID(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.OrderDetail.Update(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderdetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int orderDetailID)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailByID(orderDetailID);
                if (orderDetail != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.OrderDetail.Remove(orderDetail);
                    context.SaveChanges();
                }
                else { throw new Exception("The orderdetail does not already exist"); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
