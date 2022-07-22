using AspStore.Domain.Entities;
using System.Collections.Generic;

namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class Carrinho : Entity
    {
        public int UsuarioId { get; set; }
        public IEnumerable<ProdutoCarrinho> ProdutoCarrinho { get; set; }
    }
}
