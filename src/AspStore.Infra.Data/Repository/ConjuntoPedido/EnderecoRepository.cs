using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Infra.Data.ORM;

namespace AspStore.Infra.Data.Repository.ConjuntoPedido
{
    public class EnderecoRepository : GenericRepository<Endereco> , IEnderecoRepository
    {
        public EnderecoRepository(AspStoreDbContext context) : base (context)
        {

        }
    }
}
