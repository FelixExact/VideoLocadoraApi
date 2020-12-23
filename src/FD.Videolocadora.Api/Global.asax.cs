using System.Web.Http;
//using FD.Videolocadora.Application.AutoMapper;

namespace FD.Videolocadora.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AutoMapperConfig.RegisterMappings();
        }
    }
}
