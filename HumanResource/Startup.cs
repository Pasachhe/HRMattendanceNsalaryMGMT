using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HumanResource.Startup))]
namespace HumanResource
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
