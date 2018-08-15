using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowIt.WebMVC.Startup))]
namespace KnowIt.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
