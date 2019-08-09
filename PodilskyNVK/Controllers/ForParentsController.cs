using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    [RequireHttps]
    public class ForParentsController : Controller
    {
        IRepository repository;
        public ForParentsController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index(int page = 1)
        {
            ViewBag.Header = "Батькам";
            var news = repository.PostsList().Where(p => p.Themes.Any(t => t.Name == "Батькам"));
            var nvm = Pager.Paging(news, page);
            return View("NewsFeed", nvm);
        }
    }
}