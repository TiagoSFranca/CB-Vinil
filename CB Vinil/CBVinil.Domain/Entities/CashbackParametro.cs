namespace CBVinil.Domain.Entities
{
    public class CashbackParametro
    {
        public int IdCaskbackParametro { get; set; }
        public int IdGeneroMusical { get; set; }
        public int IdDiaSemana { get; set; }
        public decimal Percentual { get; set; }

        public virtual GeneroMusical GeneroMusical { get; set; }
        public virtual DiaSemana DiaSemana { get; set; }
    }
}
