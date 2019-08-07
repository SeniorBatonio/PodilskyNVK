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
        public ActionResult AddPhotos(object input)
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
                    photos.Add(photo);
                }
            }
            repository.SavePhotos(photos);
            return RedirectToAction("Index");
        }
    }
}