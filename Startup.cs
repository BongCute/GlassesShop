using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlassesShop.Startup))]
namespace GlassesShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
