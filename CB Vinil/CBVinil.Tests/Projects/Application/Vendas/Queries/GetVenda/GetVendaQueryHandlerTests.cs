using CBVinil.Application.Exceptions;
using CBVinil.Application.Vendas.Queries.GetVenda;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Vendas.Queries.GetVenda
{
    public class GetVendaQueryHandlerTests : TestBase<VendaTestSeed>
    {
        private readonly GetVendaQueryHandler _queryHandler;

        public GetVendaQueryHandlerTests()
            : base(new VendaTestSeed())
        {
            _queryHandler = new GetVendaQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task Success_GetVenda()
        {
            var vendas = _context.Venda.ToList();
            foreach (var venda in vendas)
            {
                var query = new GetVendaQuery() { Id = venda.IdVenda };
                var result = await _queryHandler.Handle(query, CancellationToken.None);
                Assert.NotNull(result);
                Assert.Equal(venda.IdVenda, result.IdVenda);
            }
        }

        [Theory]
        [InlineData(33)]
        [InlineData(27)]
        public async Task Error_NotFound(int id)
        {
            var query = new GetVendaQuery() { Id = id };
            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(query, CancellationToken.None));
        }
    }
}
