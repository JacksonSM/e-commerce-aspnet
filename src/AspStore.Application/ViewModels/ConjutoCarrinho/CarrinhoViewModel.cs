using AspStore.Entities.ValueObjects;
using System.Collections.Generic;

namespace AspStore.Application.ViewModels.ConjutoCarrinho
{
    public class CarrinhoViewModel
    {
        public int? Id { get; set; }
        public CPF CPF { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public List<ProdutoCarrinhoViewModel> ProdutoCarrinhoModelView { get; set; }

        public void AdicionarProduto(ProdutoCarrinhoViewModel produto)
        {
            if (produto != null)
            {
                ProdutoCarrinhoModelView.Add(produto);
            }
        }
        public void RemoverProduto(int id)
        {
            if (ProdutoCarrinhoModelView.Exists(p => p.Id == id))
            {
                var pdt = ProdutoCarrinhoModelView.Find(p => p.Id == id);
                ProdutoCarrinhoModelView.Remove(pdt);
            }
        }
    }
}