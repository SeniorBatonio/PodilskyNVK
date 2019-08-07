using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    [RequireHttps]
    public class AboutSchoolController : Controller
    {
        IRepository repository;
        public AboutSchoolController(IRepository r)
        {
            repository = r;
        }


        public ActionResult SchoolHistory()
        {
            ViewBag.Header = "Історія школи";
            var post = repository.PostsList().ToList().Where(p => p.Themes.Any(t => t.Name == "Історія школи")).First();
            return View("GetPost", post);
        }

        [Authorize(Roles = "Director")]
        [HttpGet]
        public ActionResult AddEmployee()
        {
            var roles = new SelectList(Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>());
            ViewBag.Roles = roles;
            return View();
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            var file = Request.Files.Get("Image");
            if (file != null)
            {
                employee.Photo = new byte[file.ContentLength];
                file.InputStream.Read(employee.Photo, 0, file.ContentLength);
            }

            repository.SaveEmployee(employee);
            return RedirectToAction("Administration");
        }

        public ActionResult Administration()
        {
            ViewBag.Header = "Адміністрація";
            return View("ListEmployees", repository.EmployeesList().Where(e=> e.Role == EmployeeRole.Administration));
        }

        public ActionResult TeachersLounge()
        {
            ViewBag.Header = "Вчительська";
            return View("ListEmployees", repository.EmployeesList().Where(e => e.Role == EmployeeRole.Teacher));
        }

        public ActionResult Index()
        {
            ViewBag.Header = "Про школу";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Про школу"));
            return View("NewsFeed", news);
        }

        public ActionResult MethodicalWork()
        {
            ViewBag.Header = "Методична робота";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Методична робота"));
            return View("NewsFeed", news);
        }

        public ActionResult SchoolHelp()
        {
            ViewBag.Header = "Допомога школі";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Допомога школі"));
            return View("NewsFeed", news);
        }

        public ActionResult NUS()
        {
            ViewBag.Header = "НУШ";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "НУШ"));
            return View("NewsFeed", news);
        }

        public ActionResult Documents()
        {
            ViewBag.Header = "Документи";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Документи"));
            return View("NewsFeed", news);
        }

        public ActionResult Library()
        {
            ViewBag.Header = "Бібліотека";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Бібліотека"));
            return View("NewsFeed", news);
        }

        public ActionResult PreSchool()
        {
            ViewBag.Header = "Дошкілля";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Дошкілля"));
            return View("NewsFeed", news);
        }
    }
}