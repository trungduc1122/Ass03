using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository = null;

        public ProductController() => productRepository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            var list = productRepository.GetProducts();
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductById(id.Value);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.AddProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.AddProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
        //HomeController/Index
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
