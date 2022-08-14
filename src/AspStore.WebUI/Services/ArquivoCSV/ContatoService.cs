using AspStore.WebUI.Models;
using AspStore.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspStore.WebUI.Services.ArquivoCSV
{
    public class ContatoService : IContatoService
    {
        public string FilePath { get; set; }
        public ContatoService([Microsoft.AspNetCore.Mvc.FromServices] IWebHostEnvironment webHostEnvironment)

        {
            FilePath = $"{webHostEnvironment.WebRootPath}\\arquivos_csv\\contato.csv";

            if (!Directory.Exists(webHostEnvironment.WebRootPath + "\\arquivos_csv\\"))
                Directory.CreateDirectory(webHostEnvironment.WebRootPath + "\\arquivos_csv\\");
        }
        public async Task SalvarContato(ContatoModel contato)
        {
            var contatoSeparado = $"{contato.Email};{contato.Telefone};" +
                $"{contato.LinkTwitter};{contato.LinkFacebook};{contato.Rua};{contato.NumeroEndereco};{contato.CEP};{contato.Cidade}" +
                $";{contato.Bairro}";        

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Email;Telefone;LinkTwitter;LinkFacebook;Rua;NumeroEndereco;CEP;Cidade;Bairro");
            sb.AppendLine(contatoSeparado);
            await File.WriteAllTextAsync(FilePath, sb.ToString(), Encoding.UTF8);
        }

        public ContatoModel ObterContato()
        {
            if (!File.Exists(FilePath)) return new ContatoModel();
            var contato = new ContatoModel();
            using (StreamReader reader = new StreamReader(File.OpenRead(FilePath)))
            {
                string linha;
                string[] linhaDividida;
                while (!reader.EndOfStream)
                {
                    linha = reader.ReadLine();
                    linhaDividida = linha.Split(';');
                    if (linhaDividida[0] == "Email") continue;
                    contato.Email = linhaDividida[0];
                    contato.Telefone = linhaDividida[1];
                    contato.LinkTwitter = linhaDividida[2];
                    contato.LinkFacebook = linhaDividida[3];
                    contato.Rua = linhaDividida[4];
                    contato.NumeroEndereco = linhaDividida[5];
                    contato.CEP = linhaDividida[6];
                    contato.Cidade = linhaDividida[7];
                    contato.Bairro = linhaDividida[8];
                }
            }
            return contato;
        }
    }
}
