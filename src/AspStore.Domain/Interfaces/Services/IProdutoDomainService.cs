using AspStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services
{
    public interface IProdutoDomainService : IGenericDomainService <Produto>
    {
        Task<int> GerarCodigoInterno();
        Task<IEnumerable<Produto>> TodosProdutoComCategoria();
    }
}
