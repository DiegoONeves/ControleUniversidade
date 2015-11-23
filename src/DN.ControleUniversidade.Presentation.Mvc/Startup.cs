using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DN.ControleUniversidade.Presentation.Mvc.Startup))]
namespace DN.ControleUniversidade.Presentation.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
