using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amigos.Startup))]
namespace Amigos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
