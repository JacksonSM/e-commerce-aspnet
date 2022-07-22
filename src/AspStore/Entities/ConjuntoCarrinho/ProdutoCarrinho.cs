namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class ProdutoCarrinho
    {
        public int CarrinhoId { get; set; }
        public int ProdutoId{ get; set; }
        public Produto Produto { get; set; }
    }
}
