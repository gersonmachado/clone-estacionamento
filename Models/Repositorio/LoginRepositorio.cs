using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamentoFaculdade.Models.Contexto;
using ProjetoEstacionamentoFaculdade.Models.Interface;


namespace ProjetoEstacionamentoFaculdade.Models.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly SistemaEstacionamentoDbContext _context;

        public LoginRepositorio(SistemaEstacionamentoDbContext context) 
        { 
            _context = context;
        }


        public async Task<LoginModel> Login(LoginModel login)
        {
            var dados = await _context.Cadastros.FirstOrDefaultAsync(x => x.NomeCompleto == login.NomeCompleto && x.Senha == login.Senha);

            if(dados == null) {
                throw new ArgumentException("Cadastro não encontrado no banco, por favor faça seu cadastro e tente novamente");
            
            }
            LoginModel loginModel = new LoginModel
            {
                NomeCompleto = login.NomeCompleto,
                Senha = login.Senha,
               
            };

            return loginModel;
                
        }


    }
}
