using FD.Videolocadora.Presentation.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FD.Videolocadora.Presentation.UI.Controllers
{
    public class ContaController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        public UserManager<IdentityUser> UserManager

        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<IdentityUser>>();
                }
                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }
        private SignInManager<IdentityUser, string> _signInManager;
        public SignInManager<IdentityUser, string> SignInManager
        {
            get
            {
                if (_signInManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _signInManager = contextOwin.GetUserManager<SignInManager<IdentityUser, string>>();
                }
                return _signInManager;
            }
            set
            {
                _signInManager = value;
            }
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                var contexoOwin = Request.GetOwinContext();
                return contexoOwin.Authentication;
            }
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                //mandando pra model

                var novoUsuario = new IdentityUser();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;

                var resultado = await UserManager.CreateAsync(novoUsuario, modelo.Senha);
                if (resultado.Succeeded)
                {
                    //await EnviarEmailDeConfirmacaoAsync(novoUsuario);
                    //return View("AguardandoConfirmacao");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AdicionaErros(resultado);
                }

            }
            return View(modelo);
        }

        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ContaLoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);
                if (usuario == null) { return senhaOuUsuarioInvalidos(); }
                if (usuario != null)
                {
                    var signInResultado =
                       await SignInManager.PasswordSignInAsync(
                           usuario.UserName,
                           modelo.Senha,
                           isPersistent: modelo.ContinuarLogado,
                           shouldLockout: false);

                    switch (signInResultado)
                    {
                        case SignInStatus.Success:
                            return RedirectToAction("Index", "Home");
                        default:
                            return senhaOuUsuarioInvalidos();
                    }
                }
                // relaizar login
            }
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }







        //------------------ 
        private ActionResult senhaOuUsuarioInvalidos()
        {
            ModelState.AddModelError("", "Credenciais invalidas");
            return View("login");
        }

        private async Task EnviarEmailDeConfirmacaoAsync(IdentityUser usuario)
        {
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(usuario.Id);

            var linkDeCallback =
                Url.Action(
                    "ConfirmacaoEmail",
                    "Conta",
                    new { usuarioId = usuario.Id, token = token },
                        Request.Url.Scheme);

            await UserManager.SendEmailAsync(
                usuario.Id,
                "Confirmação de cadastro",
                $"Bem vindo ao fórum ByteBank, clique aqui {linkDeCallback} para confirmar seu email!");
        }

        public ActionResult ConfirmacaoEmail(string usuarioId, string token)
        {
            throw new NotImplementedException();
        }

        private void AdicionaErros(IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError("", erro);
        }
    }
}