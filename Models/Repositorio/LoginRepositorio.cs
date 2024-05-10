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
            LoginModel loginModel = new LoginModel()
            {
                NomeCompleto = login.NomeCompleto
            };

            return loginModel;
                
        }









        /*
public async Task<LoginModel> Login(LoginModel login)
{
   var dadosCadastrados = await _context.Cadastros
       .FirstOrDefaultAsync( x => x.NomeCompleto.Equals(login.NomeCompleto) && x.Senha.Equals(login.Senha));

   var dadosParaLogin = new LoginModel()
   {
       NomeCompleto = login.NomeCompleto,
       Senha = login.Senha
   };

   if( login.Senha != loginValido.Senha) {
       throw new ArgumentException("Usuário não encontrado, por favor faça seu cadastro para continuar");




   return dadosParaLogin;
}
*/

    }
}
