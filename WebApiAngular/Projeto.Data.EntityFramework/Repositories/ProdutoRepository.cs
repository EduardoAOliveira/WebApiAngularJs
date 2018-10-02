using Projeto.Data.Contracts;
using Projeto.Data.EntityFramework.Context;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Projeto.Data.EntityFramework.Repositories
{
    public class ProdutoRepository
        : BaseRepository<Produto>, IProdutoRepository
    {
        //atributo..
        private readonly DataContext context;

        //construtor com entrada de argumentos
        public ProdutoRepository(DataContext context)
            : base(context) //construtor da superclasse
        {
            this.context = context;
        }

        public override List<Produto> FindAll()
        {
            return context.Produto
                    .Include(p => p.Estoque) //JOIN..
                    .ToList();
        }

        public override Produto FindById(int id)
        {
            return context.Produto
                    .Include(p => p.Estoque) //JOIN..
                    .FirstOrDefault(p => p.IdProduto == id);
        }
    }
}
