using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web ;

namespace AspStore.Application.ViewModels
{
    public class ImagemViewModel
    {
        [DisplayName(displayName: "Nome")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName(displayName: "Caminho")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Caminho { get; set; }
        public bool Principal { get; set; }

        public int ProdutoId { get; set; }
    }
}
