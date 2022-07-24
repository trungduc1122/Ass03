using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class OrderDetailsController : Controller
    {
        IOrderDetailRepository orderDetailRepository = null;

        public OrderDetailsController() => orderDetailRepository   = new OrderDetailRepository();
        // GET: OrderDetailsController
        public ActionResult Index()
        {
            var list = orderDetailRepository.GetOrderDetail();
            return View();
        }

        // GET: OrderDetailsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderDetail = orderDetailRepository.GetOrderDetailByID(id.Value);
            return View(orderDetail);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderDetailRepository.AddOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderDetail);
            }
        }

        // GET: OrderDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderDetailRepository.UpdateOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderDetail);
            }
        }

        // GET: OrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderDetailRepository.AddOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderDetail);
            }
        }
        //HomeController/Index
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
