using AspStore.Domain.Entities;
using AspStore.Entities.Pedido;
using System;
using System.Collections.Generic;

namespace AspStore.Entities.Pedido
{
    public class Pedido : Entity
    {
        public Cliente Cliente { get; set; }
        public int NumeroPedido { get; private set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get;private set; }
        public double ValorEnvio { get;private set; }
        public bool PedidoConfirmado { get;private set; }
        public Endereco Endereco { get; set; }
        public int ProdutoPedidoID { get; set; }
        public virtual IEnumerable<ProdutoPedido> Produto { get; set; }
    }
}
