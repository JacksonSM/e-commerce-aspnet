namespace AspStore.Application.ViewModels.ConjutoPedido
{
    public class ProdutoPedidoViewModel
    {
        public double PrecoUnidade { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}