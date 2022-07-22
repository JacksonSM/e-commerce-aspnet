using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Entities.ValueObjects;
using System.Collections.Generic;

namespace AspStore.Entities
{
    public class Cliente : Entity
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public int EnderecoId { get; set; }
        public virtual IEnumerable<Endereco> Endereco { get; set; }
        public int CarrinhoId { get; set; }
        public virtual IEnumerable<Produto> Carrinho { get; private set; }
    }
}
