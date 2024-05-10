using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamentoFaculdade.Models;
using ProjetoEstacionamentoFaculdade.Models.EnumTipoVeiculo;
using ProjetoEstacionamentoFaculdade.Models.Interface;
using System;

namespace ProjetoEstacionamentoFaculdade.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ICadastroRepositorio _cadastroRepositorio;
        public CadastroController(ICadastroRepositorio cadastroRepositorio) 
        {
            _cadastroRepositorio = cadastroRepositorio;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CadastroModel model)
        {

            await _cadastroRepositorio.CadastrarUsuario(model);
            return RedirectToAction("Index", "Login");

          
        }

       
    }
}
