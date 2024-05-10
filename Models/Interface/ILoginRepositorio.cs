namespace ProjetoEstacionamentoFaculdade.Models.Interface
{
    public interface ILoginRepositorio
    {
        Task<LoginModel> Login(LoginModel login);
    }
}
