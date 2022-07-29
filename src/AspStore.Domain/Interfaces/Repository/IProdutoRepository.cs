using AspStore.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        Task<int> GerarCodigoInterno(); 
        Task<IEnumerable<Produto>> TodosProdutoComCategoria(); 
    }
}
