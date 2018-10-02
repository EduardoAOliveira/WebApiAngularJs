using AutoMapper;
using Projeto.Entities;
using Projeto.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Profiles
{
    public class EntityToViewModelProfile : Profile
    {
        //construtor [ctor] + 2x[tab]
        public EntityToViewModelProfile()
        {
            //DE -> PARA
            CreateMap<Estoque, EstoqueConsultaViewModel>()
                .AfterMap((src, dest) =>
                    dest.QtdProdutos = src.Produtos.Sum(p => p.Quantidade));

            //DE -> PARA
            CreateMap<Produto, ProdutoConsultaViewModel>()
                .AfterMap((src, dest) =>
                    dest.NomeProduto = src.Nome)
                .AfterMap((src, dest) =>
                    dest.NomeEstoque = src.Estoque.Nome)
                .AfterMap((src, dest) =>
                    dest.Total = src.Preco * src.Quantidade);
        }
    }
}