﻿using AspStore.Entities;

namespace AspStore.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Descricao { get; set; }
        public int CodigoInterno { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Produto(){}
    }
}
