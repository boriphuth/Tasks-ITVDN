using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Controllers.Startup))]
namespace Controllers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
