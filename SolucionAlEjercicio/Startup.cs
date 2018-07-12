using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolucionAlEjercicio.Startup))]
namespace SolucionAlEjercicio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
