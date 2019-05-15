using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Top_2000_mvc.Startup))]
namespace Top_2000_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
