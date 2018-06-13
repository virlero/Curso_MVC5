using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfCodeFirstUsers.Startup))]
namespace EfCodeFirstUsers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
