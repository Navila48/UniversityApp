using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityApp.Startup))]
namespace UniversityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
