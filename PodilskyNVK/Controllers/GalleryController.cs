using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
    [RequireHttps]
    public class GalleryController : Controller
    {
        IRepository repository;
        public GalleryController(IRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            return View(repository.PhotoList().Reverse());
        }

        [Authorize(Roles = "Director, Admin")]
        [HttpGet]
        public ActionResult AddPhotos()
        {
            return View();
        }

        [Authorize(Roles = "Director, Admin")]
        [HttpPost]
        public ActionResult AddPhotos(string[] addedImages)
        {
            List<Photo> photos = new List<Photo>();
            foreach (var img in addedImages)
            {
                Photo photo = new Photo();
                photo.Image = Convert.FromBase64String(img);
                photos.Add(photo);
            }
            repository.AddPhotos(photos);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Director, Admin")]
        public ActionResult DeletePhoto(int id)
        {
            repository.DeletePhoto(id);

            return RedirectToAction("Index");
        }
    }
}