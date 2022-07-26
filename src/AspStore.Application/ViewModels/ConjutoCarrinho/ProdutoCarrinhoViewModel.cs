using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels.ConjutoCarrinho
{
    public class ProdutoCarrinhoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public int CarrinhoId { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }

        [DisplayName(displayName: "Quantidade")]
        public int Quantidade { get; private set; }

        [DisplayName(displayName: "Preço")]
        public double Preco { get; set; }

        public ProdutoCarrinhoViewModel(int carrinhoId,
            int produtoId, ProdutoViewModel produto)
        {
            CarrinhoId = carrinhoId;
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = 1;
            Preco = produto.Preco;
        }
        public void AumentarQuantidade() => Quantidade++;
        public void DiminuirQuantidade() => Quantidade--;
        public void QuantidadeEscolhida(int qnt)
        {
            if(qnt < 0) {
                throw new Exception(message: "Quantidade Escolhida não pode ser menor do que zero.");
            }
            Quantidade = qnt;
        }
    }
}
