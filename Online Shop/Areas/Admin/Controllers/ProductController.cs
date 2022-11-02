using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Data;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductController(ApplicationDbContext db,IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View((db.Products.Include(c => c.productTypes)
                .Include(m => m.specialTags)).ToList());
        }
        [HttpPost]
        public IActionResult Index(decimal ? lowAmount , decimal ? largeAmount)
        {
            List<Products> products;
            if (lowAmount == null && largeAmount==null)
            {
                 products =( db.Products.Include(c => c.productTypes)
                .Include(m => m.specialTags)).ToList();
            }
            else if (lowAmount != null && largeAmount == null)
            {
                 products =( db.Products.Include(c => c.productTypes)
                .Include(m => m.specialTags).Where(c => c.Price>=lowAmount)).ToList();
            }
            else if (lowAmount == null && largeAmount != null)
            {
                 products = (db.Products.Include(c => c.productTypes)
                .Include(m => m.specialTags).Where(c => c.Price <=largeAmount)).ToList();
            }
            else
            {
                 products = (db.Products.Include(c => c.productTypes)
               .Include(m => m.specialTags)
               .Where(c => c.Price <= largeAmount && c.Price > lowAmount)).ToList();
            }
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.productTypes.ToList(), "Id", "ProductType");
            ViewBag.SpecialTagId = new SelectList(db.specialTags.ToList(), "Id", "specialTag");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products product , IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var ImagePath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                if (image != null)
                {
                    var UniqueImageName =Guid.NewGuid().ToString()+"_"+image.FileName;
                    var uploadImage = Path.Combine(ImagePath, UniqueImageName);
                    using (var fileStram = new FileStream(uploadImage, FileMode.Create))
                    {
                        image.CopyTo(fileStram);
                    }
                    product.Image = "Images/" + UniqueImageName;
                }
                else if (image == null) //add no photo Image
                {
                    product.Image = "Images/" + "AccessNo.jpg";
                }

                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public IActionResult Edit(int ?  id)
        {
            ViewBag.ProductTypeId = new SelectList(db.productTypes.ToList(), "Id", "ProductType");
            ViewBag.SpecialTagId = new SelectList(db.specialTags.ToList(), "Id", "specialTag");

            if (id == null) return NotFound();

            var product = db.Products.Include(c=>c.productTypes)
                .Include(m=>m.specialTags).FirstOrDefault(d => d.Id==id);
            if (product ==null) return NotFound();

            return View(product);
        }
        [HttpPost]
        public async  Task<IActionResult> Edit(Products product,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image==null)
                {
                    product.Image = "Images/" + "AccessNo.jpg";
                }
                else
                {
                    var ImagePath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    var UniqueImageName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    var uploadImage = Path.Combine(ImagePath, UniqueImageName);
                    using (var fileStram = new FileStream(uploadImage, FileMode.Create))
                    {
                        image.CopyTo(fileStram);
                    }
                    product.Image = "Images/" + UniqueImageName;
                }
                db.Products.Update(product);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> delete(int ? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null) return NotFound();
                var product = db.Products.Include(c=>c.productTypes).Include(c=> c.specialTags).FirstOrDefault(c=>c.Id==id);
                if (product == null) return NotFound();

                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();




        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var product = db.Products.Include(c => c.specialTags)
                .Include(c => c.productTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
