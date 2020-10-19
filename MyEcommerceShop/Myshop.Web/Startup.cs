using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myshop.Web.Startup))]
namespace Myshop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
