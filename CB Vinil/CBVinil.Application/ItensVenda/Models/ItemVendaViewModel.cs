using CBVinil.Application.Discos.Models;

namespace CBVinil.Application.ItensVenda.Models
{
    public class ItemVendaViewModel
    {
        public int IdItemVenda { get; set; }
        public int IdDisco { get; set; }
        public int IdVenda { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorEfetivo { get; set; }
        public decimal ValorCashback { get; set; }

        public DiscoViewModel Disco { get; set; }
    }
}
