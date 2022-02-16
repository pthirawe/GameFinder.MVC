using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameFinder.MVC.Startup))]
namespace GameFinder.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
