using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iMemory.Startup))]
namespace iMemory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
