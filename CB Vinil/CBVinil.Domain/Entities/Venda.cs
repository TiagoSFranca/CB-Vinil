using System;
using System.Collections.Generic;

namespace CBVinil.Domain.Entities
{
    public class Venda
    {
        public Venda()
        {
            ItensVenda = new HashSet<ItemVenda>();
        }

        public int IdVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorEfetivo { get; set; }
        public decimal ValorCashback { get; set; }
        public DateTime DataVenda { get; set; }

        public virtual ICollection<ItemVenda> ItensVenda { get; set; }
    }
}
