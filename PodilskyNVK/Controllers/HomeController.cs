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

    [RequireHttps]
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

        //[Authorize(Roles = "Director, Admin")]
        [HttpGet]
        public ActionResult AddPost()
        {
            var themes = new SelectList(repository.ThemesList(), "Id", "Name");
            ViewBag.Themes = themes;
            return View();
        }

        //[Authorize(Roles = "Director, Admin")]
        [HttpPost]
        public ActionResult AddPost(Post post, int[] selectedThemes, string[] addedImages)
        {
            List<Photo> photos = new List<Photo>();

            foreach(var img in addedImages)
            {
                Photo photo = new Photo();
                var image = "";
                image = string.Concat(img.Skip(23));
                photo.Image = Convert.FromBase64String(image);
                photo.Post = post;
                photos.Add(photo);
            }

            foreach (var theme in repository.ThemesList().Where(t => selectedThemes.Contains(t.Id)))
            {
                post.Themes.Add(theme);
            }

            post.Photos = photos;
            post.CreationDateTime = DateTime.Now;

            repository.AddPost(post);

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Director, Admin")]
        [HttpGet]
        public ActionResult EditPost(int id) //TODO: Додати видалення теми з форми
        {
            var themes = new List<SelectList>();
            var post = repository.GetPost(id);
            foreach (var theme in post.Themes)
            {
                var selectLists = new SelectList(
                    repository.ThemesList(),
                    "Id",
                    "Name",
                    theme.Id);
                themes.Add(selectLists);
            }
            ViewBag.Themes = themes;
            return View(post);
        }

        //[Authorize(Roles = "Director, Admin")]
        [HttpPost]
        public ActionResult EditPost(Post post, int[] selectedThemes, int[] deletedPhotos, string[] addedImages)
        {
            Post newPost = repository.GetPost(post.Id);
            newPost.Header = post.Header;
            newPost.Text = post.Text;
            
            newPost.Themes.Clear();
            if (selectedThemes != null)
            {
                foreach (var theme in repository.ThemesList()
                    .Where(t => selectedThemes.Contains(t.Id)))
                {
                    newPost.Themes.Add(theme);
                }
            }

            if (deletedPhotos != null)
            {
                foreach (var photo in repository.PhotoList()
                    .Where(p => deletedPhotos.Contains(p.Id)))
                {
                    newPost.Photos.Remove(photo);
                }
            }


            repository.SavePost(newPost);

            if (addedImages != null)
            {
                foreach (var img in addedImages)
                {
                    Photo photo = new Photo();
                    var image = "";
                    image = string.Concat(img.Skip(23));
                    photo.Image = Convert.FromBase64String(image);
                    photo.Post = newPost;
                    repository.SavePhoto(photo);
                }
            }


            return RedirectToAction("Index");
        }

        public ActionResult DeletePost(int id)
        {
            repository.DeletePost(id);

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}