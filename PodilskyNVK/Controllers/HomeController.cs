using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PodilskyNVK.Controllers
{


    public class HomeController : Controller
    {
        IRepository repository;
        public HomeController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            ViewBag.Header = "Новини";
            return View("NewsFeed", repository.PostsList());
        }

        public ActionResult GetPost(int id)
        {

            return View(repository.GetPost(id));
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            var themes = new SelectList(repository.ThemesList().Where(t=>t.Name != "Історія школи"), "Id", "Name");
            ViewBag.Themes = themes;
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {
                List<Photo> photos = new List<Photo>();
                var files = Request.Files.GetMultiple("Images");
                foreach (var file in files)
                {
                    if (file.ContentLength != 0)
                    {
                        Photo photo = new Photo();
                        photo.Image = new byte[file.ContentLength];
                        file.InputStream.Read(photo.Image, 0, file.ContentLength);
                        photo.Post = post;
                        photos.Add(photo);
                    }
                }

                foreach (var theme in post.Themes)
                {
                    theme.Name = repository.GetTheme(theme.Id).Name;
                }

                post.Photos = photos;
                post.CreationDateTime = DateTime.Now;

                repository.SavePost(post);

                return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}