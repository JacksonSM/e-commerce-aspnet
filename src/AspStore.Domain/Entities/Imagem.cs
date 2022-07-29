namespace AspStore.Domain.Entities
{
    public class Imagem : Entity
    {
        public string Caminho { get; set; }
        public bool Principal { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
