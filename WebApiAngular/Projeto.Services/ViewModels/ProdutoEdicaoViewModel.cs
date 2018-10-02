using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.ViewModels
{
    public class ProdutoEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o Id do Produto")]
        public int IdProduto { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor entre {1} e {2}")]
        [Required(ErrorMessage = "Informe o preço.")]
        public decimal Preco { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe um valor entre {1} e {2}")]
        [Required(ErrorMessage = "Informe a quantidade.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o estoque.")]
        public int IdEstoque { get; set; }
    }
}