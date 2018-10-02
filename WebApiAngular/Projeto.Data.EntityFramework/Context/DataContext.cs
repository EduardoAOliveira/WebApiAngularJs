using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using Projeto.Data.EntityFramework.Mappings;
using Projeto.Entities;

namespace Projeto.Data.EntityFramework.Context
{
    //Regra 1) Herdar DbContext (EntityFramework)
    public class DataContext : DbContext
    {
        //Regra 2) Criar um construtor enviando para a superclasse
        //DbContext o caminho da connectionstring do banco de dados
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modificar as preferencias do EntityFramework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //adicionar cada classe de mapeamento
            modelBuilder.Configurations.Add(new EstoqueMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }

        //Regra 4) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
