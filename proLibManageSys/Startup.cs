using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proLibManageSys.Startup))]
namespace proLibManageSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
