using System;
using System.Collections.Generic;

namespace CBVinil.Domain.Entities
{
    public class DiaSemana
    {
        public DiaSemana()
        {
            CashbackParametros = new HashSet<CashbackParametro>();
        }

        public int IdDiaSemana { get; set; }
        public string Nome { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }

        public virtual ICollection<CashbackParametro> CashbackParametros { get; set; }
    }
}
