using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Recruitment.Startup))]
namespace E_Recruitment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
