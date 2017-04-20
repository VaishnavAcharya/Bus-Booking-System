using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusBookingSystem.WebApp.Startup))]
namespace BusBookingSystem.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
    }
}
