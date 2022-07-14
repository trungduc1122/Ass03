using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
       public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetail();
        OrderDetail GetOrderDetailByID(int orderId);
        void InsertOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int orderDetailId);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }
}
