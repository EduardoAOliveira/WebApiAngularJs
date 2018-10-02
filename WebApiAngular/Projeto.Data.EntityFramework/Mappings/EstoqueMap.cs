using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento..
using Projeto.Entities;

namespace Projeto.Data.EntityFramework.Mappings
{
    //classe de mapeamento para a entidade 'Estoque'
    public class EstoqueMap : EntityTypeConfiguration<Estoque>
    {
        //construtor
        public EstoqueMap()
        {
            //chave primária
            HasKey(e => e.IdEstoque);

            //demais campos
            Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
