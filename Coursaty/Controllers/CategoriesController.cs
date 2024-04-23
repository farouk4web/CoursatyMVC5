using Coursaty.Models;
using Coursaty.Resources;
using Coursaty.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursaty.Controllers
{
    [Authorize(Roles =RoleName.AdminsAndWorkTeam)]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        [AllowAnonymous]
        public ActionResult CategoryDetails(int id)
        {
            var categoryInDb = _context.Categories.Find(id);
            if (categoryInDb == null)
            {
                return HttpNotFound();
            }

            return View(categoryInDb);
        }
        
        public ActionResult New()
        {
            Category newCategory = new Category();

            return View("CategoryForm", newCategory);
        }

        public ActionResult Update(int id)
        {
            var categoryInDb = _context.Categories.Find(id);
            if (categoryInDb == null)
            {
                return HttpNotFound();
            }

            return View("CategoryForm", categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", category);
            }

            var categoryInDbByName = _context.Categories.SingleOrDefault(m => m.Name == category.Name);

            if (categoryInDbByName != null)
            {
                ModelState.AddModelError("Name", ModelsKeys.categoryNameExist);
                    return View("CategoryForm", category);
            }
            else if (category.Id == 0)
            {
                category.UserId = User.Identity.GetUserId();
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            else
            {
                var categoryInDb = _context.Categories.Find(category.Id);
                if (categoryInDb == null)
                {
                    return HttpNotFound();
                }
                categoryInDb.Name = category.Name;
                _context.SaveChanges();
            }

            return RedirectToAction("CategoryDetails", new { id = category.Id });
        }

        /// there is No Delete Action Because
        /// if you remove one category
        /// you are going to Delete Many Courses

    }
}