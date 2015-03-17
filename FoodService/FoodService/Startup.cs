using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodService.Startup))]
namespace FoodService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
