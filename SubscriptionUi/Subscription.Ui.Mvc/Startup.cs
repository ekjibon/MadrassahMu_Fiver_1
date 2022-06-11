using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Subscription.Ui.Mvc.Startup))]
namespace Subscription.Ui.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
