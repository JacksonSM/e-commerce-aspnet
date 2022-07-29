using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspStore.WebUI.Infra
{
    public interface IUnitOfUpload
    {
       void UploadImage(IFormFile file, string nomeImagem);
    }
}
