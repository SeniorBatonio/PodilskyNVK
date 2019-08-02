using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    public class ForParentsController : Controller
    {
        IRepository repository;
        public ForParentsController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            ViewBag.Header = "Батькам";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Батькам"));
            return View("NewsFeed", news);
        }
    }
}