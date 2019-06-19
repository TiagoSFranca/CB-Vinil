using AutoMapper;
using CBVinil.Application.Exceptions;
using CBVinil.Application.Vendas.Models;
using CBVinil.Domain.Entities;
using CBVinil.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.Vendas.Commands.VenderDiscos
{
    public class VenderDiscosCommandHandler : IRequestHandler<VenderDiscosCommand, VendaViewModel>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public async Task<VendaViewModel> Handle(VenderDiscosCommand request, CancellationToken cancellationToken)
        {
            var idDiscos = request.Discos.Select(e => e.IdDisco).Distinct().ToList();

            var discos = _context.Disco.Where(e => idDiscos.Contains(e.IdDisco)).ToList();

            var ids = discos.Select(e => e.IdDisco).ToList();

            if (idDiscos.Count != ids.Count)
                throw new NotFoundException(nameof(Disco), string.Join(",", idDiscos.Except(ids).ToList()));

            var listaVenda = request.Discos.GroupBy(e => e.IdDisco).Select(e => e.ToList())
                .Select(e => new VenderDiscoViewModel() { IdDisco = e.FirstOrDefault().IdDisco, Quantidade = e.Sum(s => s.Quantidade) }).ToList();

            var itensVenda = new List<ItemVenda>();

            var dataAtual = DateTime.Now;

            foreach (var itemLista in listaVenda)
            {
                var disco = discos.FirstOrDefault(e => e.IdDisco == itemLista.IdDisco);

                var cbParametro = _context.CashbackParametro.FirstOrDefault(e => e.DiaSemana.DiaDaSemana == dataAtual.DayOfWeek && e.IdGeneroMusical == disco.IdGeneroMusical);

                if (cbParametro == null)
                    throw new BusinessException("Percentual de cashback não encontrado");

                var valorTotal = disco.Preco * itemLista.Quantidade;
                var valorCb = valorTotal * cbParametro.Percentual;

                var itemVenda = new ItemVenda
                {
                    Quantidade = itemLista.Quantidade,
                    IdDisco = itemLista.IdDisco,
                    ValorTotal = valorTotal,
                    PrecoUnitario = disco.Preco,
                    PercentualCashback = cbParametro.Percentual,
                    ValorCashback = valorCb,
                    ValorEfetivo = valorTotal - valorCb
                };

                itensVenda.Add(itemVenda);
            }

            var venda = new Venda
            {
                ValorTotal = itensVenda.Sum(e => e.ValorTotal),
                ValorEfetivo = itensVenda.Sum(e => e.ValorEfetivo),
                ValorCashback = itensVenda.Sum(e => e.ValorCashback),
                DataVenda = dataAtual
            };

            itensVenda.ForEach(e => { e.Venda = venda; });

            venda.ItensVenda = itensVenda;

            try
            {
                _context.Venda.Add(venda);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new PersistenceException(e);
            }

            return _mapper.Map<VendaViewModel>(venda);
        }
    }
}
