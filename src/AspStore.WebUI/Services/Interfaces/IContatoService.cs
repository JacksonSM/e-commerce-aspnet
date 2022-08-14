using AspStore.WebUI.Models;
using System.Threading.Tasks;

namespace AspStore.WebUI.Services.Interfaces
{
    public interface IContatoService
    {
        Task SalvarContato(ContatoModel contato);
        ContatoModel ObterContato();
    }
}
