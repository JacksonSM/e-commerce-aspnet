using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AspStore.Application.ViewModels.ConjutoPedido
{
    public class PedidoViewModel
    {
        [DisplayName(displayName: "Data do Pedido")]
        public DateTime DataPedido { get; set; }

        [DisplayName(displayName: "Valor Total")]
        public double ValorTotal { get; private set; }

        [DisplayName(displayName: "Valor do Frete")]
        public double ValorEnvio { get; private set; }
        public bool PedidoConfirmado { get; private set; }

        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<ProdutoPedidoViewModel> ProdutoPedido { get; set; }
    }
}
