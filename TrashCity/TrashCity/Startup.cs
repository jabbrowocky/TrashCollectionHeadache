using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashCity.Startup))]
namespace TrashCity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
