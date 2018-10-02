using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Estoque
    {
        public virtual int IdEstoque { get; set; }
        public virtual string Nome { get; set; }

        #region Relacionamentos

        public ICollection<Produto> Produtos { get; set; }

        #endregion
    }
}
