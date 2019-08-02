using Ninject.Modules;
using PodilskyNVK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodilskyNVK.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
        }
    }
}