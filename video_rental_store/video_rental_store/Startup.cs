using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(video_rental_store.Startup))]
namespace video_rental_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
