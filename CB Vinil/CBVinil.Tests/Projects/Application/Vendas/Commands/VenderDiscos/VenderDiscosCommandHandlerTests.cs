using CBVinil.Application.Exceptions;
using CBVinil.Application.Vendas.Commands.VenderDiscos;
using CBVinil.Application.Vendas.Models;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Vendas.Commands.VenderDiscos
{
    public class VenderDiscosCommandHandlerTests : TestBase<VendaTestSeed>
    {
        private readonly VenderDiscosCommandHandler _commandHandler;

        public VenderDiscosCommandHandlerTests()
            : base(new VendaTestSeed())
        {
            _commandHandler = new VenderDiscosCommandHandler(_context, _mapper);
        }

        [Fact]
        public async Task Error_VenderDiscos_DiscoNotFound()
        {
            var discos = _context.Disco.FirstOrDefault();
            var command = new VenderDiscosCommand()
            {
                Discos = new List<VenderDiscoViewModel>()
                {
                    new VenderDiscoViewModel()
                    {
                        IdDisco = discos.IdDisco,
                        Quantidade = 2
                    },
                    new VenderDiscoViewModel()
                    {
                        IdDisco = 5,
                        Quantidade = 2
                    }
                }

            };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public void Error_VenderDiscos_CashbackNotFoud()
        {
            var cashbacks = _context.CashbackParametro.ToList();
            _context.CashbackParametro.RemoveRange(cashbacks);
            _context.SaveChanges();

            var discos = _context.Disco.FirstOrDefault();

            var command = new VenderDiscosCommand()
            {
                Discos = new List<VenderDiscoViewModel>()
                {
                    new VenderDiscoViewModel()
                    {
                        IdDisco = discos.IdDisco,
                        Quantidade = 2
                    }
                }
            };

            Func<Task> action = async () => { await _commandHandler.Handle(command, CancellationToken.None); };

            var ex = Record.ExceptionAsync(action);
            Assert.IsType<BusinessException>(ex.Result);
            Assert.Contains("Percentual de cashback não encontrado", ex.Result.Message);
        }

        [Fact]
        public async Task Success_VenderDiscos()
        {
            var discos = _context.Disco.FirstOrDefault();
            var command = new VenderDiscosCommand()
            {
                Discos = new List<VenderDiscoViewModel>()
                {
                    new VenderDiscoViewModel()
                    {
                        IdDisco = discos.IdDisco,
                        Quantidade = 2
                    },
                }
            };
            var qtdVendaI = _context.Venda.Count();
            var venda = await _commandHandler.Handle(command, CancellationToken.None);
            var qtdVendaF = _context.Venda.Count();
            var qtdItens = _context.ItemVenda.Count();

            Assert.True(qtdVendaF > qtdVendaI);
            Assert.Equal(command.Discos.Count, qtdItens);
            Assert.Equal(venda.ValorTotal, command.Discos.Sum(e => e.Quantidade * discos.Preco));
        }
    }
}
