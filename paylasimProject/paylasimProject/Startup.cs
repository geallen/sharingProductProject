using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(paylasimProject.Startup))]
namespace paylasimProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
