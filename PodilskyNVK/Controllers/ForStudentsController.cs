using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    [RequireHttps]
    public class ForStudentsController : Controller
    {
        IRepository repository;
        public ForStudentsController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index(int page = 1)
        {
            ViewBag.Header = "Учням";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Учням"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult ZNOandDPA(int page = 1)
        {
            ViewBag.Header = "ЗНО та ДПА";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "ЗНО та ДПА"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult LifeSafety(int page = 1)
        {
            ViewBag.Header = "Безпека життєдіяльності";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Безпека життєдіяльності"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult UsefulInformation(int page = 1)
        {
            ViewBag.Header = "Корисна інформація";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Корисна інформація"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }

        public ActionResult LessonsSchedule(int page = 1)
        {
            return RedirectToAction("GetPost", "Home", new { id = 1022 });
        }
    }
}