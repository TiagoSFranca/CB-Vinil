using System.Collections.Generic;

namespace CBVinil.Domain.Entities
{
    public class GeneroMusical
    {
        public GeneroMusical()
        {
            CashbackParametros = new HashSet<CashbackParametro>();
            Discos = new HashSet<Disco>();
        }

        public int IdGeneroMusical { get; set; }
        public string Nome { get; set; }
        public string ArgSpotify { get; set; }

        public virtual ICollection<CashbackParametro> CashbackParametros { get; set; }
        public virtual ICollection<Disco> Discos { get; set; }
    }
}
