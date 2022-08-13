using Microsoft.AspNetCore.Http;

namespace AspStore.WebUI.Infra
{
    public interface IGerenciadorImagens
    {
        void SalvarImagemPrincipal(IFormFile imagem, int produtoCodigoInterno);
        void SalvarImagens(IFormFileCollection imagens, int produtoCodigoInterno);
        void ExcluirImagem(string nomeImagem);
        string[] BuscarImagensProduto(int produtoCodigoInterno);
        string BuscarImagemPrincipalProduto(int produtoCodigoInterno);      
    }
}
