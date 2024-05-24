using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamentoFaculdade.Models.Contexto;
using ProjetoEstacionamentoFaculdade.Models.Interface;

namespace ProjetoEstacionamentoFaculdade.Models.Repositorio
{
    public class CadastroRepositorio : ICadastroRepositorio
    {
        private readonly SistemaEstacionamentoDbContext _context;
      
        public CadastroRepositorio(SistemaEstacionamentoDbContext context) 
        {
            _context = context; 
           
        }
        public async Task<List<CadastroModel>> BuscarCadastros()
        {
            return await _context.Cadastros.ToListAsync();
        }

        public async Task<CadastroModel> BuscarCadastrosPorNome(string nome)
        {
            return await _context.Cadastros
                .Where(cad => cad.NomeCompleto == nome)
                .FirstOrDefaultAsync();
        }

        public async Task<CadastroModel> CadastrarUsuario(CadastroModel cadastroModel)
        {
            // Remover espaços em branco dos campos antes de salvar
            cadastroModel.NomeCompleto = cadastroModel.NomeCompleto.Trim();
            cadastroModel.Senha = cadastroModel.Senha.Trim();
            await _context.Cadastros.AddAsync(cadastroModel);
            await _context.SaveChangesAsync();
            return cadastroModel;

        }
    }
}
