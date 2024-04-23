using Coursaty.Models;
using Coursaty.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursaty.Controllers
{
    [Authorize(Roles = RoleName.AdminsAndWorkTeam)]
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var courses = _context.Courses.ToList();
            
            return View(courses);
        }

        [AllowAnonymous]
        public ActionResult CourseDetails(int id)
        {
            var courseInDb = _context.Courses.Find(id);
            if (courseInDb == null)
            {
                return HttpNotFound();
            }

            courseInDb.Views = courseInDb.Views + 1;
            _context.SaveChanges();

            return View(courseInDb);
        }

        public ActionResult New()
        {
            var viewModel = new CoursesFormViewModel
            {
                Course = new Course(),
                Categories = _context.Categories.ToList()
            };

            return View("CoursesForm", viewModel);
        }

        public ActionResult Update(int id)
        {
            var courseInDb = _context.Courses.Find(id);
            if (courseInDb == null)
            {
                return HttpNotFound();
            }


            var viewModel = new CoursesFormViewModel
            {
                Course = courseInDb,
                Categories = _context.Categories.ToList()
            };

            return View("CoursesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CoursesFormViewModel VM, HttpPostedFileBase coursePicture)
        {
            // REMEMBER the CoursePicture

            if (!ModelState.IsValid)
            {
                var viewModel = new CoursesFormViewModel
                {
                    Course = VM.Course,
                    Categories = _context.Categories.ToList()
                };

                return View("CoursesForm", viewModel);
            }
            

            // if TRUE ===> New Course
            if (VM.Course.Id == 0)
            {
                if (coursePicture == null)
                {
                    var viewModel = new CoursesFormViewModel
                    {
                        Course = VM.Course,
                        Categories = _context.Categories.ToList()
                    };

                    ModelState.AddModelError("", "you should choose a photo");
                    return View("CoursesForm", viewModel);
                }

                VM.Course.UserId = User.Identity.GetUserId();
                VM.Course.PublishDate = DateTime.Now;
                VM.Course.Likes = 0;
                VM.Course.Views = 0;

                _context.Courses.Add(VM.Course);
                _context.SaveChanges();

                var path = Path.Combine(Server.MapPath("~/Content/Images/Courses/"), VM.Course.Id + ".png");
                coursePicture.SaveAs(path);

                VM.Course.CoursePicture = "/Content/Images/Courses/" + VM.Course.Id + ".png";
                _context.SaveChanges();
            
            }

            // Course In Db
            else
            {
                

                var courseInDb = _context.Courses.Find(VM.Course.Id);

                courseInDb.Title = VM.Course.Title;
                courseInDb.Instructor = VM.Course.Instructor;
                courseInDb.CategoryId = VM.Course.CategoryId;
                courseInDb.Link = VM.Course.Link;


                if (coursePicture != null)
                {
                    // Remove Old Image
                    var oldImageInDb = Path.Combine(Server.MapPath("~/Content/Images/Courses/"), VM.Course.Id + ".png");
                    System.IO.File.Delete(oldImageInDb);

                    var path = Path.Combine(Server.MapPath("~/Content/Images/Courses/"), VM.Course.Id + ".png");
                    coursePicture.SaveAs(path);

                    courseInDb.CoursePicture = "/Content/Images/Courses/" + VM.Course.Id + ".png";
                }

                _context.SaveChanges();
            }

            return RedirectToAction("CourseDetails", new { id = VM.Course.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Courses.Find(id);
            if (courseInDb == null)
            {
                return HttpNotFound();
            }

            var oldImageInDb = Path.Combine(Server.MapPath("~/Content/Images/Courses/"), courseInDb.Id + ".png");
            System.IO.File.Delete(oldImageInDb);

            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}