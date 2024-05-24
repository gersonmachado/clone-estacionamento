using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamentoFaculdade.Models;
using ProjetoEstacionamentoFaculdade.Models.Contexto;
using ProjetoEstacionamentoFaculdade.Models.Interface;
using System.Security.Claims;

namespace ProjetoEstacionamentoFaculdade.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;
        public LoginController(ILoginRepositorio loginRepositorio) 
        { 
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel model)
        {

            try
            {
                var resultado = await _loginRepositorio.Login(model);
                if (resultado != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.NomeCompleto),
                        new Claim(ClaimTypes.Email, model.Senha)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true 
                    };

                    // Autentica o usuário e cria o cookie de autenticação.
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError(string.Empty, "Login inválido.");

            }
            catch (ArgumentException ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
          return View(model);
        }
    }
}
