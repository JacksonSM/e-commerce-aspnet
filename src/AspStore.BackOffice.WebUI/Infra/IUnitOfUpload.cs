using Microsoft.AspNetCore.Http;

namespace AspStore.BackOffice.WebUI.Infra
{
    public interface IUnitOfUpload
    {
        void UploadImage(IFormFile file);
    }
}
