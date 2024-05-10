using ProjetoEstacionamentoFaculdade.Models.EnumTipoVeiculo;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstacionamentoFaculdade.Models
{
    public class CadastroModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Digite o nome é um dado obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O número de celular é um dado obrigatório ")]
        [Phone(ErrorMessage = "O número do celular não é válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A placa do veículo é um dado obrigatório")]
        public string PlacaVeiculo { get;set; }

        [Required(ErrorMessage = "A tipo do veículo é um dado obrigatório")]
        public TipoVeiculoEnum TipoDoVeiculo { get; set; }

        [Required(ErrorMessage = "A senha é um dado obrigatório")]
        public string Senha { get; set; }

    }
}
