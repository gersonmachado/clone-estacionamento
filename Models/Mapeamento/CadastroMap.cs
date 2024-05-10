using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoEstacionamentoFaculdade.Models.Mapeamento
{
    public class CadastroMap : IEntityTypeConfiguration<CadastroModel>
    {
        public void Configure(EntityTypeBuilder<CadastroModel> builder)
        {
            builder.HasKey( x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NomeCompleto).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.PlacaVeiculo).IsRequired();
            builder.Property(x => x.TipoDoVeiculo).IsRequired(true);
            builder.HasAnnotation("MySql:AutoIncrement", true);
        }
    }
}
