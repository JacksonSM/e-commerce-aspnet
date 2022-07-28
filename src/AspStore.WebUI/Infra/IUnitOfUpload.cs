using Microsoft.AspNetCore.Http;

namespace AspStore.WebUI.Infra
{
    public interface IUnitOfUpload
    {
        void UploadImage(IFormFile file);
    }
}
