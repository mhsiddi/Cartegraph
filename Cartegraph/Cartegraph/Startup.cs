using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cartegraph.Startup))]
namespace Cartegraph
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
