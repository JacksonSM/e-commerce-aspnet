using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.WebUI.Infra
{
    public class GerenciadorImagens : IGerenciadorImagens
    {
        private readonly IUnitOfUpload _upload;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GerenciadorImagens(IUnitOfUpload upload, IWebHostEnvironment webHostEnvironment)
        {
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        public string BuscarImagemPrincipalProduto(int produtoCodigoInterno)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath + $"\\uploads\\imagens_produtos\\{produtoCodigoInterno}_principal.png");
            if (File.Exists(path))
            {
                return $"{produtoCodigoInterno}_principal.png";
            }
            return "";
        }
   
        public string[] BuscarImagensProduto(int produtoCodigoInterno)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath + $"\\uploads\\imagens_produtos\\");
            if (File.Exists(_webHostEnvironment.WebRootPath + $"\\uploads\\imagens_produtos\\{produtoCodigoInterno}_principal.png"))
            {
                var arquivos =  Directory.EnumerateFiles(path,$"{produtoCodigoInterno}_*", SearchOption.TopDirectoryOnly).ToArray();
                List<string> listaFileName = new List<string>();
                foreach (var item in arquivos)
                {
                    listaFileName.Add(Path.GetFileName(item));
                }
                
                return listaFileName.ToArray();
            }
            return null;
        }

        public void ExcluirImagem(string nomeImagem)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath + $"\\uploads\\imagens_produtos\\{nomeImagem}");
            File.Delete(path);
        }

        public void SalvarImagemPrincipal(IFormFile arquivo, int produtoCodigoInterno)
        {
            ExcluirImagem($"{produtoCodigoInterno}_principal.png");
            var nomeImagem = produtoCodigoInterno + "_principal";
            _upload.CarregarImagemProduto(arquivo,nomeImagem);
        }

        public void SalvarImagens(IFormFileCollection imagens, int produtoCodigoInterno)
        {
            var contador = 0;

            foreach (var imagem in imagens)
            {
                 _upload.CarregarImagemProduto(imagem, $"{produtoCodigoInterno}_{contador}");
                contador++;
            }
        }
    }
}
