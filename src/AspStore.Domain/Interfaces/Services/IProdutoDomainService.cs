using AspStore.Domain.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services
{
    public interface IProdutoDomainService : IGenericDomainService <Produto>
    {
        Task AdicionarImagem(Imagem imagem);
    }
}
