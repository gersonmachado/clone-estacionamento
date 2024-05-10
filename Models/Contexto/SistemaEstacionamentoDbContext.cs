using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamentoFaculdade.Models.Mapeamento;


namespace ProjetoEstacionamentoFaculdade.Models.Contexto
{
    public class SistemaEstacionamentoDbContext: DbContext
    {
        public SistemaEstacionamentoDbContext(DbContextOptions<SistemaEstacionamentoDbContext> options) :base(options) { }

        public DbSet<CadastroModel> Cadastros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CadastroMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
