﻿using AspStore.Application.ViewModels;
using AspStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IProdutoAppService : IGenericAppService<ProdutoViewModel,Produto>
    {
        Task<int> GerarCodigoInterno();
        Task<IEnumerable<ProdutoViewModel>> TodosProdutoComCategoria();
        Task<ProdutoViewModel> ObterProdutoComCategoria(int produtoId);
    }
}
