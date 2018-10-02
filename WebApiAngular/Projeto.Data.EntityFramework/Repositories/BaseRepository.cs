using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Contracts;
using Projeto.Data.EntityFramework.Context;
using System.Data.Entity;

namespace Projeto.Data.EntityFramework.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //atributo para o contexto do entityframework
        //readonly -> atributo somente possa ser inicializado
        //pelo método construtor da classe
        private readonly DataContext context;

        //construtor recebendo o contexto como argumento
        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
        
        public virtual List<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
