using System.Collections.Generic;

namespace CBVinil.Domain.Entities
{
    public class Disco
    {
        public Disco()
        {
            ItensVenda = new HashSet<ItemVenda>();
        }

        public int IdDisco { get; set; }
        public int IdGeneroMusical { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual GeneroMusical GeneroMusical { get; set; }
        public virtual ICollection<ItemVenda> ItensVenda { get; set; }
    }
}
