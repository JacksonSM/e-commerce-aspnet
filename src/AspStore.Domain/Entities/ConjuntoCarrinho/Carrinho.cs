using AspStore.Entities;
using AspStore.Entities.ValueObjects;
using System.Collections.Generic;

namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class Carrinho : Entity
    {
        public CPF CPF { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ProdutoCarrinho> ProdutoCarrinho { get; set; }
        public Carrinho() {}
    }
}
