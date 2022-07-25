using AspStore.Entities;
using System.Collections.Generic;

namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class Carrinho : Entity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Carrinho> ProdutoCarrinho { get; set; }
        public Carrinho() { }
    }
}
