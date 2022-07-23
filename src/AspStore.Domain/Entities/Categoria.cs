using AspStore.Domain.Entities;
using System.Collections.Generic;

namespace AspStore.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Produto> Produto { get; set; }
        public Categoria() { }
    }
}
