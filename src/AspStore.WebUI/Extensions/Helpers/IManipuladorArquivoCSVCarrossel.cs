using AspStore.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStore.WebUI.Extensions.Helpers
{
    public interface IManipuladorArquivoCSVCarrossel
    {
        Task GravarItemCarrossel(ItemCarrossel itemCarrossel);
        Task SalvarCarrossel(List<ItemCarrossel> carrossel);
        Task<List<ItemCarrossel>> ObterCarrossel();
    }
}
