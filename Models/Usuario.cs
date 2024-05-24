using ProjetoEstacionamentoFaculdade.Models.EnumTipoVeiculo;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstacionamentoFaculdade.Models
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }

        public string PlacaVeiculo { get; set; }

        public TipoVeiculoEnum TipoDoVeiculo { get; set; }

    }
}
