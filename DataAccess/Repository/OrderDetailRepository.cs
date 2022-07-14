using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailByID(int orderDetailId) => OrderDetailDAO.Instance.GetOrderDetailByID(orderDetailId);
        public IEnumerable<OrderDetail> GetOrderDetail() => OrderDetailDAO.Instance.GetOrderDetailList();
        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddNew(orderDetail);
        public void DeleteOrderDetail(int orderDetailId) => OrderDetailDAO.Instance.Remove(orderDetailId);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.Update(orderDetail);
    }
}
