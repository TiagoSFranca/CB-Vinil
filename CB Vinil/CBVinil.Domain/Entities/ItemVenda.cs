namespace CBVinil.Domain.Entities
{
    public class ItemVenda
    {
        public int IdItemVenda { get; set; }
        public int IdDisco { get; set; }
        public int IdVenda { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal PercentualCashback { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorEfetivo { get; set; }
        public decimal ValorCashback { get; set; }

        public virtual Disco Disco { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
