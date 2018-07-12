using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SideWaffleTest.Startup))]
namespace SideWaffleTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
