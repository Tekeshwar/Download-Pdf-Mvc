using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.Pdf.Startup))]
namespace App.Pdf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
