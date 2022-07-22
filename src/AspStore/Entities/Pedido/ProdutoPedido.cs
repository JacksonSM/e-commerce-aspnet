using AspStore.Domain.Entities;

namespace AspStore.Entities.Pedido
{
    public class ProdutoPedido
    {
        public Produto Produto { get; set; }
        public double PrecoUnidade { get; set; }
        public int QuantidadeUnidade { get; set; }
    }
}
