using AspStore.Entities.ValueObjects;

namespace AspStore.Entities.Pedido
{
    public class Endereco
    {
        public string NomeRecebidor { get; set; }
        public string NomeRua { get; set; }
        public int NumeroCasa { get; set; }
        public string PontoReferencia { get; set; }
        public CEP CEP { get; set; }
    }
}