using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Data.Contracts
{
    public interface IProdutoRepository
        : IBaseRepository<Produto>
    {

    }
}
