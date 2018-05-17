using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project2_BuellerWeb.Startup))]
namespace Project2_BuellerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
