using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APLI_INTRO.Startup))]
namespace APLI_INTRO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
