using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Shop.Utility;

namespace Online_Shop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrderController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CheckOut(Order order)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("_products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    order.OrderDetails.Add(orderDetails);
                }
            }
            order.OrderNo = GetOrderNo();
            db.orders.Add(order);
            await db.SaveChangesAsync();
            List<Products> productss = new List<Products>();
            HttpContext.Session.Set("_products", productss);

            return View();
        }
        public string GetOrderNo()
        {
            return (db.orders.ToList().Count + 1).ToString("000");
        }
    }
}
