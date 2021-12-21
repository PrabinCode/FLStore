using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FLStore.Web.Startup))]
namespace FLStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
