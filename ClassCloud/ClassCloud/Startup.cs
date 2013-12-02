using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassCloud.Startup))]
namespace ClassCloud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
