namespace AspStore.Domain.Entities.ConjuntoCarrinho
{
    public class ProdutoCarrinho : Entity
    {
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public ProdutoCarrinho() { }
    }
}
