using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace AspStore.WebUI.Infra
{
    public class UnitOfUpload : IUnitOfUpload
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public UnitOfUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async void UploadImage(IFormFile file, string codigo)
        {
            long totalBytes = file.Length;
            string fileName = file.FileName.Trim('"');
            var extension = Path.GetExtension(fileName);
            fileName = codigo + extension;
    



            fileName = fileName.Contains("\\") ? fileName.Substring(fileName.LastIndexOf("\\") + 1) : fileName;

            byte[] buffer = new byte[2048 * 1024];
            using (FileStream output = File.Create(ObterCaminhoMaisNomeDoArquivo(fileName)))
            {
                using (Stream input = file.OpenReadStream())
                {
                    int readBytes;
                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }           
        }
        private string ObterCaminhoMaisNomeDoArquivo(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\imagens_produtos\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return path + fileName;
        }
    }
}
