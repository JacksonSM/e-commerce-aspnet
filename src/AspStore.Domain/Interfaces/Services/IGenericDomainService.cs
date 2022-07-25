using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services
{
    public interface IGenericDomainService<T>
    {
        Task Adicionar(T obj);
        Task Atualizar(T obj);
        Task Excluir(T obj);
    }
}
