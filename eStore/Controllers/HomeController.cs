using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //MemberController/Index
        public ActionResult MemberIndex()
        {
            return RedirectToAction("Index","Members");
        }
        //ProductController/Index
        public ActionResult ProductIndex()
        {
            return RedirectToAction("Index", "Products");
        }
        //OrderController/Index
        public ActionResult OrderIndex()
        {
            return RedirectToAction("Index", "Orders");
        }
        //OrderDetailController/Index
        public ActionResult OrderDetailIndex()
        {
            return RedirectToAction("Index", "OrderDetails");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}