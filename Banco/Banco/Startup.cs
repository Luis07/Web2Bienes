using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Banco.Startup))]
namespace Banco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
