using CBVinil.Application.GenerosMusicais.Queries.GetGenerosMusicais;
using CBVinil.Domain.Seeds;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.GenerosMusicais.Queries.GetGenerosMusicais
{
    public class GetGenerosMusicaisQueryHandlerTests : TestBase<GeneroMusicalTestSeed>
    {
        private readonly GetGenerosMusicaisQueryHandler _queryHandler;

        public GetGenerosMusicaisQueryHandlerTests()
            : base(new GeneroMusicalTestSeed())
        {
            _queryHandler = new GetGenerosMusicaisQueryHandler(_context, _mapper);
        }

        public static IEnumerable<object[]> _getQueries()
        {
            yield return new object[] { new GetGenerosMusicaisQuery() };
            yield return new object[] { new GetGenerosMusicaisQuery() { Nome = "Disco 01" } };
            yield return new object[] { new GetGenerosMusicaisQuery() { Ids = new List<int>() { 1, 2 } } };
        }

        [Theory]
        [MemberData(nameof(_getQueries))]
        public async Task Success_Get_WithParams(GetGenerosMusicaisQuery query)
        {
            var result = await _queryHandler.Handle(query, CancellationToken.None);
            var countSeed = CountExpectedGenerosMusicais(query);
            Assert.NotNull(result);
            Assert.Equal(countSeed, result.Count);
        }

        private int CountExpectedGenerosMusicais(GetGenerosMusicaisQuery request)
        {
            var query = GeneroMusicalSeed.Seeds.AsQueryable();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdGeneroMusical));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            return query.Count();
        }
    }
}
