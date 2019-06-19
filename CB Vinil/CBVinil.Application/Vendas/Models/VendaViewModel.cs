using CBVinil.Application.ItensVenda.Models;
using System;
using System.Collections.Generic;

namespace CBVinil.Application.Vendas.Models
{
    public class VendaViewModel
    {
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorEfetivo { get; set; }
        public decimal ValorCashback { get; set; }

        public List<ItemVendaViewModel> ItensVenda { get; set; }
    }
}
