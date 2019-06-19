using CBVinil.Domain.Entities;
using System.Collections.Generic;

namespace CBVinil.Domain.Seeds
{
    public static class CashbackParametroSeed
    {
        public static List<CashbackParametro> CashbackPop()
        {
            return new List<CashbackParametro>()
            {
                new CashbackParametro()
                {
                    IdCaskbackParametro = 1,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Domingo.IdDiaSemana,
                    Percentual = .25M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 2,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Segunda.IdDiaSemana,
                    Percentual = .07M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 3,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Terca.IdDiaSemana,
                    Percentual = .06M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 4,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quarta.IdDiaSemana,
                    Percentual = .02M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 5,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quinta.IdDiaSemana,
                    Percentual = .1M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 6,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sexta.IdDiaSemana,
                    Percentual = .15M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 7,
                    IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sabado.IdDiaSemana,
                    Percentual = .2M
                },
            };
        }

        public static List<CashbackParametro> CashbackMpb()
        {
            return new List<CashbackParametro>()
            {
                new CashbackParametro()
                {
                    IdCaskbackParametro = 11,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Domingo.IdDiaSemana,
                    Percentual = .3M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 12,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Segunda.IdDiaSemana,
                    Percentual = .05M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 13,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Terca.IdDiaSemana,
                    Percentual = .1M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 14,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quarta.IdDiaSemana,
                    Percentual = .15M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 15,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quinta.IdDiaSemana,
                    Percentual = .2M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 16,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sexta.IdDiaSemana,
                    Percentual = .25M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 17,
                    IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sabado.IdDiaSemana,
                    Percentual = .3M
                },
            };
        }

        public static List<CashbackParametro> CashbackClassic()
        {
            return new List<CashbackParametro>()
            {
                new CashbackParametro()
                {
                    IdCaskbackParametro = 21,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Domingo.IdDiaSemana,
                    Percentual = .35M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 22,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Segunda.IdDiaSemana,
                    Percentual = .03M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 23,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Terca.IdDiaSemana,
                    Percentual = .05M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 24,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quarta.IdDiaSemana,
                    Percentual = .08M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 25,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quinta.IdDiaSemana,
                    Percentual = .13M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 26,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sexta.IdDiaSemana,
                    Percentual = .18M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 27,
                    IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sabado.IdDiaSemana,
                    Percentual = .25M
                },
            };
        }

        public static List<CashbackParametro> CashbackRock()
        {
            return new List<CashbackParametro>()
            {
                new CashbackParametro()
                {
                    IdCaskbackParametro = 31,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Domingo.IdDiaSemana,
                    Percentual = .4M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 32,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Segunda.IdDiaSemana,
                    Percentual = .1M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 33,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Terca.IdDiaSemana,
                    Percentual = .15M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 34,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quarta.IdDiaSemana,
                    Percentual = .15M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 35,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Quinta.IdDiaSemana,
                    Percentual = .15M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 36,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sexta.IdDiaSemana,
                    Percentual = .2M
                },
                new CashbackParametro()
                {
                    IdCaskbackParametro = 37,
                    IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                    IdDiaSemana = DiaSemanaSeed.Sabado.IdDiaSemana,
                    Percentual = .4M
                },
            };
        }

        public static List<CashbackParametro> Seeds
        {
            get
            {
                var lista = new List<CashbackParametro>();
                lista.AddRange(CashbackPop());
                lista.AddRange(CashbackMpb());
                lista.AddRange(CashbackClassic());
                lista.AddRange(CashbackRock());
                return lista;
            }
        }
    }
}
