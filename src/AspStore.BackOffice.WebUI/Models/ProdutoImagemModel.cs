using AspStore.Application.ViewModels;
using AspStore.Domain.Entities;

namespace AspStore.BackOffice.WebUI.Models
{
    public class ProdutoImagemModel
    {
        public ProdutoViewModel ProdutoVM { get; set; }
        public Imagem ImagemModel { get; set; }
    }
}
