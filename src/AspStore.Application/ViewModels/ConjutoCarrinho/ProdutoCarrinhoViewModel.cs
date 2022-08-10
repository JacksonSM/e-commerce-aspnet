using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels.ConjutoCarrinho
{
    public class ProdutoCarrinhoViewModel
    {
        public int Id { get; set; }
        public int CodigoInterno { get; set; }
        public int CarrinhoId { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }

        [DisplayName(displayName: "Quantidade")]
        public int Quantidade { get; private set; }

        [DisplayName(displayName: "Preço")]
        public decimal Preco { get; set; }

        public ProdutoCarrinhoViewModel(int carrinhoId, ProdutoViewModel produto)
        {
            CarrinhoId = carrinhoId;
            if (produto != null)
            {
                ProdutoId = produto.Id;
                Produto = produto;
                Quantidade = 1;
                Preco = produto.Preco;
                CodigoInterno = produto.CodigoInterno;
                Nome = produto.Nome;
            }
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
