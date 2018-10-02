using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.ViewModels
{
    public class ProdutoConsultaViewModel
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public int IdEstoque { get; set; }
        public string NomeEstoque { get; set; }
    }
}