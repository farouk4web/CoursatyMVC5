using Coursaty.Models;
using Coursaty.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursaty.Controllers
{
    [Authorize(Roles = RoleName.Admins)]
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admins
        public ActionResult Index()
        {
            var AdminsRole = _context.Roles.SingleOrDefault(r => r.Name == RoleName.Admins);

            List<ApplicationUser> Admins = new List<ApplicationUser>();

            foreach (var user in AdminsRole.Users)
            {
                var adminUser = _context.Users.Find(user.UserId);
                Admins.Add(adminUser);
            }

            return View(Admins);
        }

        // GET: Users
        public ActionResult Users()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        // GET: Users
        [AllowAnonymous]
        public ActionResult UserAccount(string id)
        {
            var userInDb = _context.Users.Find(id);
            if (userInDb == null)
                return HttpNotFound();

            var viewModel = new UserAccountViewModel
            {
                User = userInDb,
                IsAdmin = false,
                IsFromWorkTeam = false
            };

            var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            if (_userManager.IsInRole(userInDb.Id, RoleName.Admins))
                viewModel.IsAdmin = true;

            if (_userManager.IsInRole(userInDb.Id, RoleName.WorkTeam))
                viewModel.IsFromWorkTeam= true;

            return View(viewModel);
        }

        // add user to admin 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserToRole(string userId, string roleName)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            _userManager.AddToRole(userId, roleName);

            return RedirectToAction("UserAccount", new { id = userId });
        }

        //Remove user From Admins
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserFromRole(string userId, string roleName)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            // admin trying to remove himself
            else if(userId == User.Identity.GetUserId() && roleName== RoleName.Admins)
                return RedirectToAction("Index", "Home");

            var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            _userManager.RemoveFromRole(userId, roleName);

            return RedirectToAction("UserAccount", new { id = userId});
        }



        // just in DEVELOPMENT MODE To create the admin, workTeam Role
        // then take role sql code from sqlServer and put it 
        // as codefirst migration

        //public ActionResult CreateRole()
        //{
        //    IdentityRole role = new IdentityRole
        //    {
        //        Name = RoleName.WorkTeam
        //    };

        //    _context.Roles.Add(role);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Home");
        //}

    }
}