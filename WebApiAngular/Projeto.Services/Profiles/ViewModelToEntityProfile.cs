using AutoMapper;
using Projeto.Entities;
using Projeto.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Profiles
{
    public class ViewModelToEntityProfile : Profile
    {
        //construtor [ctor] + 2x[tab]
        public ViewModelToEntityProfile()
        {
            //DE -> PARA
            CreateMap<EstoqueCadastroViewModel, Estoque>();
            CreateMap<EstoqueEdicaoViewModel, Estoque>();

            //DE -> PARA
            CreateMap<ProdutoCadastroViewModel, Produto>();
            CreateMap<ProdutoEdicaoViewModel, Produto>();
        }
    }
}