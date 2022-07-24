using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepository = null;

        public OrderController() => orderRepository = new OrderRepository();
        // GET: OrderController
        public ActionResult Index()
        {
            var list = orderRepository.GetOrders();
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderById(id.Value);
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.AddOrder(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.UpdateOrder(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.AddOrder(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
        //HomeController/Index
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

