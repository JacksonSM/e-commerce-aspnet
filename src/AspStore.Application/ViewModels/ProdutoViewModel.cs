﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspStore.Application.ViewModels.ConjutoCarrinho
{
    public class ProdutoViewModel
    {
        [DisplayName(displayName: "Nome")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName(displayName: "Preço")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public double Preco { get; set; }

        [DisplayName(displayName: "Estoque")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        public int Estoque { get; set; }

        public int CategoriaId { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }
    }
}