using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Shop.Areas.Admin.Models;
using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,ApplicationDbContext db,
            UserManager<IdentityUser>userManager)
        {
            this.roleManager = roleManager;
            this.db = db;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
             
            var roles = roleManager.Roles.ToList();
            ViewBag.roles = roles;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(String roleName)
        {
            
            var IsExist = await roleManager.RoleExistsAsync(roleName);
            if (IsExist)
            {
                ViewBag.msg = "this role is already Exist";
                ViewBag.roleName = roleName;
                return View();
            }
            else
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleName;
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["save"] = "Role has been creates successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task <ActionResult> Edit(String ? id)
        {
            if (id == null) return NotFound();
            var role =  await  roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            ViewBag.id = id;
            ViewBag.name = role.Name;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Edit(string roleName , String id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            role.Name = roleName;

           var result =  await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> details(String? id)
        {
            if (id == null) return NotFound();
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            ViewBag.name = role.Name;
            ViewBag.id = role.Id;

            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Assign()
        {
            ViewData["UserId"] = new SelectList(db.ApplicationUsers.ToList(), "Id", "UserName");
            ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Assign(RolesUserViewModel model)
        {
            var user = db.ApplicationUsers.Where(c=> c.LockoutEnd<DateTime.Now||c.LockoutEnd==null).FirstOrDefault(u => u.Id == model.UserId);
            var IsAlreadyInRole = await userManager.IsInRoleAsync(user, model.RoleId);
            if (IsAlreadyInRole)
            {
                ViewBag.msg = "this user already assign this role";
                ViewData["UserId"] = new SelectList(db.ApplicationUsers.ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
                return View();

            }
            var result = await userManager.AddToRoleAsync(user, model.RoleId);
            if (result.Succeeded)
            {
                TempData["save"] = "User Role Assigned.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public ActionResult AssignUserRole()
        {
            var result = from ur in db.UserRoles
                         join r in db.Roles on ur.RoleId equals r.Id
                         join a in db.ApplicationUsers on ur.UserId equals a.Id
                         select new UserRoleMapping()
                         {
                             UserId = ur.UserId,
                             RoleId = r.Id,
                             UserName = a.UserName,
                             RoleName = r.Name
                         };
            ViewBag.UserRoles = result;
            return View();
        }
    }
}
