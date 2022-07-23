using AspStore.Domain.Entities;

namespace AspStore.Domain.Entities.ConjuntoPedido
{
    public class ProdutoPedido : Entity
    {
        public double PrecoUnidade { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public ProdutoPedido() { }
    }
}
