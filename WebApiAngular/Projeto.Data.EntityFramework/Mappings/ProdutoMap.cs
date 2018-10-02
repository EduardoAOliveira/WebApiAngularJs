using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento
using Projeto.Entities; //classes de entidade

namespace Projeto.Data.EntityFramework.Mappings
{
    //classe de mapeamento para a entidade Produto
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        //construtor
        public ProdutoMap()
        {
            //chave primária
            HasKey(p => p.IdProduto);

            //demais campos
            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Preco)
                .HasPrecision(18,2)
                .IsRequired();

            Property(p => p.Quantidade)                
                .IsRequired();

            Property(p => p.IdEstoque)
                .IsRequired();

            #region Relacionamentos

            HasRequired(p => p.Estoque) //Produto TEM 1 Estoque
                .WithMany(e => e.Produtos) //Estoque TEM Muitos Produtos
                .HasForeignKey(p => p.IdEstoque); //Chave estrangeira

            #endregion
        }
    }
}
