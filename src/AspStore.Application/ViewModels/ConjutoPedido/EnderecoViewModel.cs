using AspStore.Domain.Emuns;
using AspStore.Entities.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels.ConjutoPedido
{
    public class EnderecoViewModel
    {
        public int ClienteId { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }

        [DisplayName(displayName: "Logradouro")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [DisplayName(displayName: "Número")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public int Numero { get; set; }

        [DisplayName(displayName: "Bairro")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [DisplayName(displayName: "Complemento")]
        [StringLength(maximumLength: 250, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Complemento { get; set; }

        [DisplayName(displayName: "Cidade")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [DisplayName(displayName: "Cidade")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }
        public CEP CEP { get; set; }
    }
}
