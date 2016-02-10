using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyDiscount.Web.Startup))]
namespace CompanyDiscount.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
