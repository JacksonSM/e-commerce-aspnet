using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Entities.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels
{
    public class ClienteViewModel
    {
        [DisplayName(displayName: "Nome")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public CarrinhoViewModel Carrinho { get; set; }
        public IEnumerable<EnderecoViewModel> Endereco { get; set; }
        public IEnumerable<PedidoViewModel> Pedido { get; set; }
    }
}
