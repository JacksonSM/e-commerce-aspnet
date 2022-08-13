using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspStore.WebUI.Infra
{
    public interface IUnitOfUpload
    {
        void CarregarImagemProduto(IFormFile file, string codigo);
        void CarregarImagemCarrossel(IFormFile file, string nomeImagem);
    }
}
