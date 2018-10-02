using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.ViewModels
{
    public class EstoqueConsultaViewModel
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        public int QtdProdutos { get; set; }
    }
}