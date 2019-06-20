using CBVinil.Application.Discos.Queries.GetDiscos;
using CBVinil.Application.Paginacoes.Models;
using CBVinil.Common.Constants;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Discos.Queries.GetDiscos
{
    public class GetDiscosQueryHandlerTests : TestBase<DiscoTestSeed>
    {
        private readonly GetDiscosQueryHandler _queryHandler;

        public GetDiscosQueryHandlerTests()
            : base(new DiscoTestSeed())
        {
            _queryHandler = new GetDiscosQueryHandler(_context, _mapper);
        }

        public static IEnumerable<object[]> _getQueries()
        {
            yield return new object[] { new GetDiscosQuery() };
            yield return new object[] { new GetDiscosQuery() { Nome = "Disco 01" } };
            yield return new object[] { new GetDiscosQuery() { Ids = new List<int>() { 1, 2 } } };
            yield return new object[] { new GetDiscosQuery() { IdGenerosMusicais = new List<int>() { 1, 2 } } };
            yield return new object[] { new GetDiscosQuery() { NomeGeneroMusical = "Pop" } };
        }

        [Theory]
        [MemberData(nameof(_getQueries))]
        public async Task Success_Get_WithParams(GetDiscosQuery query)
        {
            var result = await _queryHandler.Handle(query, CancellationToken.None);
            var countSeed = CountExpectedDiscos(query);
            Assert.NotNull(result);
            Assert.Equal(countSeed, result.Itens.Count);
        }

        private int CountExpectedDiscos(GetDiscosQuery request)
        {
            var query = _context.Disco.AsQueryable();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdDisco));

            if (request.IdGenerosMusicais?.Count > 0)
                query = query.Where(e => request.IdGenerosMusicais.Contains(e.IdGeneroMusical));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            if (!string.IsNullOrEmpty(request.NomeGeneroMusical))
                query = query.Where(e => e.GeneroMusical.Nome.ToLower().Contains(request.NomeGeneroMusical.ToLower()));

            var paginacao = request.Paginacao ?? new PaginacaoViewModel(PaginacaoConstants.PaginaDefault, PaginacaoConstants.ItensPorPaginaDefault);

            var resultado = query.Skip((paginacao.Pagina - 1) * paginacao.ItensPorPagina).Take(paginacao.ItensPorPagina).Count();

            return resultado;
        }
    }
}
