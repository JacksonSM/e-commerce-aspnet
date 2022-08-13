using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspStore.WebUI.Models
{
    public class CarrosselModel
    {
        public ItemCarrossel ItemPrincipal { get; set; }
        public List<ItemCarrossel> ColecaoItemCarrossel { get; set; }  
    }
    public class ItemCarrossel
    {
        [Range(1,4, ErrorMessage ="São permitidos apenas números de {1} a {2}")]
        public int Ordem { get; set; } 
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
    }
    

}
