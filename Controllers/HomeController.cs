using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamentoFaculdade.Models;
using ProjetoEstacionamentoFaculdade.Models.Interface;
using System.Diagnostics;

namespace ProjetoEstacionamentoFaculdade.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ICadastroRepositorio _cadastroRepositorio;

        public HomeController(ICadastroRepositorio cadastroRepositorio)
        {
            _cadastroRepositorio = cadastroRepositorio;
        }

        public IActionResult Index()
        {
            var user = User.Identity.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Vagas")]

        public async Task<IActionResult> Vagas()
        {
            var userName = User.Identity.Name;

            var user = await _cadastroRepositorio.BuscarCadastrosPorNome(userName);

            var resposta = new Usuario
            {
                NomeCompleto = user.NomeCompleto,
                PlacaVeiculo = user.PlacaVeiculo,
                TipoDoVeiculo = user.TipoDoVeiculo
            };
            return View(resposta);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
