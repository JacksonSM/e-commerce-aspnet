using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels.ConjutoCarrinho
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        [DisplayName(displayName: "Nome")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }
        public IEnumerable<ProdutoViewModel> Produto { get; set; }
    }
}