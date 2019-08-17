using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAP_Tec_Test.Startup))]
namespace GAP_Tec_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
