using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Data;
using Online_Shop.Models;
using Online_Shop.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Online_Shop.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        public const string SessionKeyProducts = "_products";

        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index( int ? page)
        {

            return View(db.Products.Include(p => p.productTypes)
                .Include(p => p.specialTags).ToList().ToPagedList(pageNumber : page ?? 1 , pageSize : 3));
        }
         [HttpGet]
        public IActionResult Details( int ? id)
        {
            if (id == null) return NotFound();
            var prodcut = db.Products.Include(p => p.productTypes)
                .Include(p => p.specialTags).FirstOrDefault(p => p.Id == id);
            if (prodcut==null) return NotFound();
                
            return View(prodcut);
        }   
        [HttpPost]
        [ActionName("Details")]
        public IActionResult productDetails(int? id)
        {
            List<Products> products = new List<Products>();

            if (id == null) return NotFound();

            var prodcut = db.Products.Include(p => p.productTypes)
                .Include(p => p.specialTags).FirstOrDefault(p => p.Id == id);

            if (prodcut == null) return NotFound();
            products = HttpContext.Session.Get<List<Products>>(SessionKeyProducts);
            if (products == null)
            {
                products = new List<Products>();
            }

           Products AreProductInChart = products.FirstOrDefault(p=> p.Id==prodcut.Id);
            if (AreProductInChart==null) //to avoid refresh
            {
                products.Add(prodcut);
                HttpContext.Session.Set(SessionKeyProducts, products);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [HttpGet]
        [ActionName("remove")]
        public IActionResult removeProductFromChart (int ? id)
        {
          List<Products>products = HttpContext.Session.Get<List<Products>>(SessionKeyProducts);
            if (products != null)
            {
                var removedProdcut = products.Find(m => m.Id == id);
                if (removedProdcut != null)
                {
                    products.Remove(removedProdcut);
                    HttpContext.Session.Set(SessionKeyProducts, products);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult chart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>(SessionKeyProducts);
            return View(products);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
