using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Entities;
using System;
using System.Collections.Generic;

namespace AspStore.Domain.Entities.ConjuntoPedido
{
    public class Pedido : Entity
    {
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; private set; }
        public double ValorEnvio { get; private set; }
        public bool PedidoConfirmado { get; private set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public virtual IEnumerable<Carrinho> Carrinho { get; set; }
    }
}
