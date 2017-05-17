using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COMP4900Project.Startup))]
namespace COMP4900Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
