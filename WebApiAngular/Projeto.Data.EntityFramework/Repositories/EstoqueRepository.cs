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
    public class EstoqueRepository
        : BaseRepository<Estoque>, IEstoqueRepository
    {
        //atributo..
        private readonly DataContext context;

        //construtor com entrada de argumentos
        public EstoqueRepository(DataContext context)
            : base(context) //construtor da superclasse
        {
            this.context = context;
        }

        public override List<Estoque> FindAll()
        {
            return context.Estoque
                    .Include(e => e.Produtos) //JOIN..
                    .ToList();
        }

        public override Estoque FindById(int id)
        {
            return context.Estoque
                    .Include(e => e.Produtos) //JOIN..
                    .FirstOrDefault(e => e.IdEstoque == id);
        }
    }
}
