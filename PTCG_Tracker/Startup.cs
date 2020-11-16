using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTCG_Tracker.Startup))]
namespace PTCG_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
