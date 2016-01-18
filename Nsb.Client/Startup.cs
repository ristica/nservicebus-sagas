using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nsb.Client.Startup))]
namespace Nsb.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
