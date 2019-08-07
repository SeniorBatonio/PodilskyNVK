using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PodilskyNVK.Startup))]
namespace PodilskyNVK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
