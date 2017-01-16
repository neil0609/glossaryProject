using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlossaryProject.Startup))]
namespace GlossaryProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
