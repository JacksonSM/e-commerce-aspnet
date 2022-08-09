using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Entities.ValueObjects;
using System.Collections.Generic;

namespace AspStore.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public int CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }
        public IEnumerable<Endereco> Endereco { get; set; }
        public IEnumerable<Pedido> Pedido { get; set; }
        public Cliente(){ }
    }
}
