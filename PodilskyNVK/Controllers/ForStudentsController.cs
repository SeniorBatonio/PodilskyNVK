using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    public class ForStudentsController : Controller
    {
        IRepository repository;
        public ForStudentsController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            ViewBag.Header = "Учням";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Учням"));
            return View("NewsFeed", news);
        }

        public ActionResult ZNOandDPA()
        {
            ViewBag.Header = "ЗНО та ДПА";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "ЗНО та ДПА"));
            return View("NewsFeed", news);
        }

        public ActionResult LifeSafety()
        {
            ViewBag.Header = "Безпека життєдіяльності";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Безпека життєдіяльності"));
            return View("NewsFeed", news);
        }

        public ActionResult UsefulInformation()
        {
            ViewBag.Header = "Корисна інформація";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Корисна інформація"));
            return View("NewsFeed", news);
        }
    }
}