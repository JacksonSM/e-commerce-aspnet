using AspStore.Entities;

namespace AspStore.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Produto(){}
    }
}
