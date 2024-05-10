using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamentoFaculdade.Models;
using ProjetoEstacionamentoFaculdade.Models.Contexto;
using ProjetoEstacionamentoFaculdade.Models.Interface;

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
                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
