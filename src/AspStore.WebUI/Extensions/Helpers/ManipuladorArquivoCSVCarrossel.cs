using AspStore.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspStore.WebUI.Extensions.Helpers
{
    public class ManipuladorArquivoCSVCarrossel : IManipuladorArquivoCSVCarrossel
    {
        public string FilePath { get; set; }
        public ManipuladorArquivoCSVCarrossel([Microsoft.AspNetCore.Mvc.FromServices] IWebHostEnvironment webHostEnvironment)
        
        {
            FilePath = $"{webHostEnvironment.WebRootPath}\\arquivos_csv\\carrossel.csv";

            if (!Directory.Exists(webHostEnvironment.WebRootPath + "\\arquivos_csv\\")) 
                Directory.CreateDirectory(webHostEnvironment.WebRootPath + "\\arquivos_csv\\");
        }

        public async Task GravarItemCarrossel(ItemCarrossel itemCarrossel)
        {
            var itemSeparado = $"{itemCarrossel.Ordem};{itemCarrossel.Titulo};{itemCarrossel.Descricao};{itemCarrossel.URL}";
            var carrossel = await ObterCarrossel();

            if (carrossel.Exists(i => i.Ordem == itemCarrossel.Ordem))
            {
                var item = carrossel.FirstOrDefault(item => item.Ordem == itemCarrossel.Ordem);
                carrossel.Remove(item);
                carrossel.Add(itemCarrossel);
            }
            else
            {
                carrossel.Add(itemCarrossel);
            }
            await SalvarCarrossel(carrossel);
        }
        public async Task SalvarCarrossel(List<ItemCarrossel> carrossel)
        {           
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ordem;Titulo;Descricao;URL");
            carrossel.ForEach(car => sb.AppendLine($"{car.Ordem};{car.Titulo};{car.Descricao};{car.URL}"));
            await File.WriteAllTextAsync (FilePath, sb.ToString(), Encoding.UTF8);
        }
        public async Task<List<ItemCarrossel>> ObterCarrossel()
        {
            if (!File.Exists(FilePath)) return new List<ItemCarrossel>();

            var listaItemCarrossel = new List<ItemCarrossel>();
            using (StreamReader reader = new StreamReader(File.OpenRead(FilePath))){      
                string linha;
                string[] linhaDivOrdemOrdema;
                while (!reader.EndOfStream)
                {
                    linha = reader.ReadLine();
                    linhaDivOrdemOrdema = linha.Split(';');
                    if (linhaDivOrdemOrdema[0] == "Ordem") continue;
                    listaItemCarrossel.Add(new ItemCarrossel
                    {
                        Ordem = int.Parse(linhaDivOrdemOrdema[0]),
                        Titulo = linhaDivOrdemOrdema[1],
                        Descricao = linhaDivOrdemOrdema[2],
                        URL = linhaDivOrdemOrdema[3]
                    });
                }
            }
            return  listaItemCarrossel.OrderBy(anuncio => anuncio.Ordem).ToList();
        }
    }
}
