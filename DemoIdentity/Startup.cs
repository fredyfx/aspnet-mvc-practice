using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoIdentity.Startup))]
namespace DemoIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
