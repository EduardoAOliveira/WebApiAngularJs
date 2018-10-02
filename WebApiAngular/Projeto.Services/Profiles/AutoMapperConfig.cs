using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Profiles
{
    public class AutoMapperConfig
    {
        //método para registrar as classes
        //Profile criadas com o AutoMapper
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToViewModelProfile>();
                cfg.AddProfile<ViewModelToEntityProfile>();
            });
        }
    }
}