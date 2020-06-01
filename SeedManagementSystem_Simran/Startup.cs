using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeedManagementSystem_Simran.Startup))]
namespace SeedManagementSystem_Simran
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
