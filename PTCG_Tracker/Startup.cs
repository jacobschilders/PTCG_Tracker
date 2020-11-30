using Microsoft.Owin;
using Owin;
using Microsoft.SqlServer;
using PTCG_Tracker.Data;

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
