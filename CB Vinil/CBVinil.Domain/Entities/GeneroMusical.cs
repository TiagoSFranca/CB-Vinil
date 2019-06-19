using System.Collections.Generic;

namespace CBVinil.Domain.Entities
{
    public class GeneroMusical
    {
        public GeneroMusical()
        {
            CashbackParametros = new HashSet<CashbackParametro>();
        }

        public int IdGeneroMusical { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CashbackParametro> CashbackParametros { get; set; }
    }
}
