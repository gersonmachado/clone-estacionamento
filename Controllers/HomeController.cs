using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamentoFaculdade.Models;
using System.Diagnostics;

namespace ProjetoEstacionamentoFaculdade.Controllers
{
    public class HomeController : Controller
    {
  

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Vagas")]
        public IActionResult Vagas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
