using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFitness.Startup))]
namespace MyFitness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
