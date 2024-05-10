using Microsoft.AspNetCore.Mvc;

namespace ProjetoEstacionamentoFaculdade.Models.Interface
{
    public interface ICadastroRepositorio
    {
        Task<List<CadastroModel>> BuscarCadastros();
        Task<CadastroModel> CadastrarUsuario(CadastroModel cadastroModel);
    }
}
