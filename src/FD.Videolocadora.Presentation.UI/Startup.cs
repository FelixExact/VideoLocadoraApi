using FD.Videolocadora.Presentation.UI.App_Start.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(FD.Videolocadora.Presentation.UI.Startup))]

namespace FD.Videolocadora.Presentation.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.CreatePerOwinContext<DbContext>(() =>
            new IdentityDbContext<IdentityUser>("Videolocadora1"));

            builder.CreatePerOwinContext<IUserStore<IdentityUser>>(
            (opcoes, contextoOwin) =>
             {
                 var dbContext = contextoOwin.Get<DbContext>();
                 return new UserStore<IdentityUser>(dbContext);
             });

            builder.CreatePerOwinContext<UserManager<IdentityUser>>(
            (opcoes, contextoOwin) =>
            {
                var userStore = contextoOwin.Get<IUserStore<IdentityUser>>();
                var userManager = new UserManager<IdentityUser>(userStore);
                //Validando email unico:
                var userValidator = new UserValidator<IdentityUser>(userManager);
                userValidator.RequireUniqueEmail = true;

                userManager.UserValidator = userValidator;
                userManager.EmailService = new EmailServico();

                var dataProtectionProvider = opcoes.DataProtectionProvider;
                var dataProtectionProviderCreated = dataProtectionProvider.Create("FD.Videolocadora.Presentation.UI");
                userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProviderCreated);


                return userManager;
            });
            builder.CreatePerOwinContext<SignInManager<IdentityUser, string>>(
            (opcoes, contextoOwin) =>
            {
                var userManager = contextoOwin.Get<UserManager<IdentityUser>>();

                var signInManager = new SignInManager<IdentityUser, string>(
                    userManager,
                    contextoOwin.Authentication);

                return signInManager;
            });

            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

        }
    }
}