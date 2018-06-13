using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutenticacionDosFactores_twilio.Startup))]
namespace AutenticacionDosFactores_twilio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
