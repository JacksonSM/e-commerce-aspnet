using AspStore.Entities;
using System.Collections.Generic;

namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class Carrinho : Entity
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<ProdutoCarrinho> ProdutoCarrinho { get; set; }
    }
}
