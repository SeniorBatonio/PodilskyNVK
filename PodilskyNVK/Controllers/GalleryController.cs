using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Controllers
{
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
    }
}