using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductTypesController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View(db.productTypes.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(ProductTypes productTypeName )
        {
            if (ModelState.IsValid)
            {
                db.productTypes.Add(productTypeName);
                await  db.SaveChangesAsync();
                TempData["save"] = "Product Type Has been Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypeName);

        }
        [HttpGet]

        public IActionResult Edit(int ? id )
        {
            var productType = db.productTypes.Find(id);
            if (productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes model)
        {

            if (ModelState.IsValid)
            {
                db.productTypes.Update(model);
                await db.SaveChangesAsync();
                TempData["update"] = "Product Type Has been updated";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var productType = db.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Details(ProductTypes model)
         {
             return RedirectToAction(actionName: nameof(Index));
         }*/

        [HttpGet]
        public async Task<IActionResult>Delete(int ? id )
         {
            if (id== null)
            {
                return NotFound();
            }
            var productType = db.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                db.productTypes.Remove(productType);
                await db.SaveChangesAsync();
                TempData["delete"] = "Product Type Has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
