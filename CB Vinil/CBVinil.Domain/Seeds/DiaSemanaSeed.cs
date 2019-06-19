using CBVinil.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CBVinil.Domain.Seeds
{
    public static class DiaSemanaSeed
    {
        public static DiaSemana Domingo => new DiaSemana() { IdDiaSemana = 1, Nome = "Domingo", DiaDaSemana = DayOfWeek.Sunday };
        public static DiaSemana Segunda => new DiaSemana() { IdDiaSemana = 2, Nome = "Segunda", DiaDaSemana = DayOfWeek.Monday };
        public static DiaSemana Terca => new DiaSemana() { IdDiaSemana = 3, Nome = "Terça", DiaDaSemana = DayOfWeek.Tuesday };
        public static DiaSemana Quarta => new DiaSemana() { IdDiaSemana = 4, Nome = "Quarta", DiaDaSemana = DayOfWeek.Wednesday };
        public static DiaSemana Quinta => new DiaSemana() { IdDiaSemana = 5, Nome = "Quinta", DiaDaSemana = DayOfWeek.Thursday };
        public static DiaSemana Sexta => new DiaSemana() { IdDiaSemana = 6, Nome = "Sexta", DiaDaSemana = DayOfWeek.Friday };
        public static DiaSemana Sabado => new DiaSemana() { IdDiaSemana = 7, Nome = "Sábado", DiaDaSemana = DayOfWeek.Saturday };

        public static List<DiaSemana> Seeds => new List<DiaSemana>()
        {
            Domingo,
            Segunda,
            Terca,
            Quarta,
            Quinta,
            Sexta,
            Sabado
        };
    }
}
