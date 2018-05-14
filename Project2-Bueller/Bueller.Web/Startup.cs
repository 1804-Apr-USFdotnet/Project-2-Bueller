using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bueller.Web.Startup))]
namespace Bueller.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
