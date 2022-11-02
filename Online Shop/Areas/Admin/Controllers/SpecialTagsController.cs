using Microsoft.AspNetCore.Http;
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
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext db;

        public SpecialTagsController(ApplicationDbContext _db)
        {
            db = _db;
        }
        // GET: SpecialTagsController
        public ActionResult Index()
        {
            
            return View(db.specialTags.ToList());
        }

        // GET: SpecialTagsController/Details/5
        public ActionResult Details(int id)
        {
            var tag = db.specialTags.Find(id);
            if (tag==null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: SpecialTagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialTagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task <ActionResult> Create(SpecialTags model)
        {
            if (ModelState.IsValid)
            {
                db.specialTags.Add(model);
               await db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(model);  
        }

        // GET: SpecialTagsController/Edit/5
        public ActionResult Edit(int id)
        {
            var tag = db.specialTags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);

        }

        // POST: SpecialTagsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SpecialTags model)
        {
            if (ModelState.IsValid)
            {
                db.specialTags.Update(model);
                await db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(model);
            


        }

        // GET: SpecialTagsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tag = db.specialTags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                db.specialTags.Remove(tag);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

       /* // POST: SpecialTagsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
