using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentStation.Startup))]
namespace RentStation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
