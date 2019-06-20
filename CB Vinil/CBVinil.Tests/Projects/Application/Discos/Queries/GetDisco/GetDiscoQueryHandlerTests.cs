using CBVinil.Application.Discos.Queries.GetDisco;
using CBVinil.Application.Exceptions;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Discos.Queries.GetDisco
{
    public class GetDiscoQueryHandlerTests : TestBase<DiscoTestSeed>
    {
        private readonly GetDiscoQueryHandler _queryHandler;

        public GetDiscoQueryHandlerTests()
            : base(new DiscoTestSeed())
        {
            _queryHandler = new GetDiscoQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task Success_GetDisco()
        {
            var discos = _context.Disco.ToList();
            foreach (var disco in discos)
            {
                var query = new GetDiscoQuery() { Id = disco.IdDisco };
                var result = await _queryHandler.Handle(query, CancellationToken.None);
                Assert.NotNull(result);
                Assert.Equal(disco.IdDisco, result.IdDisco);
                Assert.Equal(disco.Nome, result.Nome);
                Assert.Equal(disco.Artistas, result.Artistas);
            }
        }

        [Theory]
        [InlineData(33)]
        [InlineData(27)]
        public async Task Error_NotFound(int id)
        {
            var query = new GetDiscoQuery() { Id = id };
            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(query, CancellationToken.None));
        }
    }
}
