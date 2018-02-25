using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Travelling.Web.Startup))]
namespace Travelling.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
