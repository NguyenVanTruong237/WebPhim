using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPhim.Startup))]
namespace WebPhim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
