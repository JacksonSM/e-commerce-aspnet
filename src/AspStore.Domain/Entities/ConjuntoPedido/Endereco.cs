using AspStore.Domain.Emuns;
using AspStore.Entities.ValueObjects;

namespace AspStore.Domain.Entities.ConjuntoPedido
{
    public class Endereco : Entity
    {
        public int ClienteId { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public CEP CEP { get; set; }
    }
}