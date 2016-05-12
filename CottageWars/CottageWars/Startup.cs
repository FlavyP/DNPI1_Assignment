using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CottageWars.Startup))]
namespace CottageWars
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
