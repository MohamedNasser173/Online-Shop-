using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext db;

        public UserController(UserManager<IdentityUser>userManager,ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser User)
        {
            if (ModelState.IsValid)
            {
                
                    var result = await userManager.CreateAsync(User, User.PasswordHash);
                    if (result.Succeeded)
                    {
                    var isSaveRole = await userManager.AddToRoleAsync(User, role : "User");
                        TempData["save"] = "User has been created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(String.Empty, error.Description);
                        }
                    }

                
               
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
                
            return View(user);
        }
        [HttpPost]
        public async  Task<ActionResult> Edit(ApplicationUser user)
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id);
            if (userInfo == null) return NotFound();

            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;

           var result =   await userManager.UpdateAsync(userInfo);
            if (result.Succeeded)
            {
                TempData["save"] = "User has been updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }

            return View(user);
        }
        public ActionResult Details(String id)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }
        public ActionResult LocOut(String id)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }
        [HttpPost]
        public ActionResult LocOut(ApplicationUser user)
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id);
            if (user == null) return NotFound();
            userInfo.LockoutEnd = DateTime.Now.AddYears(20);
           int rowAffected= db.SaveChanges();
            if(rowAffected > 0)
            {
                TempData["save"] = "User has been LocOut Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
        [HttpGet]
        public ActionResult Active(String id)
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (userInfo == null) return NotFound();
            return View(userInfo);
        }
        [HttpPost]
        public ActionResult Active(ApplicationUser user)
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == user.Id);
            if (user == null) return NotFound();
            userInfo.LockoutEnd = DateTime.Now.AddDays(-1);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been Active Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
        /*public ActionResult delete(String id)
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (userInfo == null) return NotFound();
            return View(userInfo);
        }*/
        public ActionResult delete(string id )
        {
            var userInfo = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (userInfo == null) return NotFound();
            db.ApplicationUsers.Remove(userInfo);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been deleted Successfully";
               
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
