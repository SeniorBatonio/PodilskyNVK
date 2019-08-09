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
        public ActionResult AddEmployee(Employee employee, string addedPhoto)
        {
            if (addedPhoto != null)
            {
                employee.Photo = Convert.FromBase64String(addedPhoto);
            }

            repository.AddEmployee(employee);
            return RedirectToAction("Administration");
        }

        [Authorize(Roles = "Director")]
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var employee = repository.GetEmployee(id);
            var roles = new SelectList(Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>(), employee.Role);
            ViewBag.Roles = roles;
            return View(employee);
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        public ActionResult EditEmployee(Employee employee, string addedPhoto, bool? isDeleted)
        {
            var newEmployee = repository.GetEmployee(employee.Id);
            newEmployee.Name = employee.Name;
            newEmployee.Position = employee.Position;
            newEmployee.AboutEmploee = employee.AboutEmploee;
            newEmployee.Role = employee.Role;

            if (isDeleted != null && isDeleted == true)
            {
                newEmployee.Photo = null;
            }
            if (addedPhoto != null)
            {
                newEmployee.Photo = Convert.FromBase64String(addedPhoto);
            }

            repository.SaveEmployee(newEmployee);

            return RedirectToAction("Administration");
        }

        [Authorize(Roles = "Director")]
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            repository.DeleteEmployee(id);

            return RedirectToAction("Index");
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

        public ActionResult Index(int page = 1)
        {
            ViewBag.Header = "Про школу";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Про школу"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult MethodicalWork(int page = 1)
        {
            ViewBag.Header = "Методична робота";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Методична робота"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult SchoolHelp(int page = 1)
        {
            ViewBag.Header = "Допомога школі";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Допомога школі"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult NUS(int page = 1)
        {
            ViewBag.Header = "НУШ";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "НУШ"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult Documents(int page = 1)
        {
            ViewBag.Header = "Документи";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Документи"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult Library(int page = 1)
        {
            ViewBag.Header = "Бібліотека";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Бібліотека"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult PreSchool(int page = 1)
        {
            ViewBag.Header = "Дошкілля";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Дошкілля"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }
    }
}