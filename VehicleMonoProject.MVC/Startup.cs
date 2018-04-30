using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleMonoProject.MVC.Startup))]
namespace VehicleMonoProject.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
