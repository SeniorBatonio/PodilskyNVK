using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PodilskyNVK.Models;
using PodilskyNVK.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PodilskyNVK
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            // Remove data annotations validation provider 
            ModelValidatorProviders.Providers.Remove(
                        ModelValidatorProviders.Providers.OfType<DataAnnotationsModelValidatorProvider>().First());
        }
    }
}
