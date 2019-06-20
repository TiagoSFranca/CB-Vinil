using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Queries.GetVendas;
using CBVinil.Common.Constants;
using CBVinil.Tests.Settings;
using CBVinil.Tests.Settings.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CBVinil.Tests.Projects.Application.Vendas.Queries.GetVendas
{
    public class GetVendasQueryHandlerTests : TestBase<VendaTestSeed>
    {
        private readonly GetVendasQueryHandler _queryHandler;

        public GetVendasQueryHandlerTests()
            : base(new VendaTestSeed())
        {
            _queryHandler = new GetVendasQueryHandler(_context, _mapper);
        }

        public static IEnumerable<object[]> _getQueries()
        {
            yield return new object[] { new GetVendasQuery() };
            yield return new object[] { new GetVendasQuery() { DataFim = DateTime.Now } };
            yield return new object[] { new GetVendasQuery() { Ids = new List<int>() { 1, 2 } } };
            yield return new object[] { new GetVendasQuery() { DataInicio = DateTime.Now.AddDays(-2) } };
        }

        [Theory]
        [MemberData(nameof(_getQueries))]
        public async Task Success_Get_WithParams(GetVendasQuery query)
        {
            var result = await _queryHandler.Handle(query, CancellationToken.None);
            var countSeed = CountExpectedVendas(query);
            Assert.NotNull(result);
            Assert.Equal(countSeed, result.Itens.Count);
        }

        private int CountExpectedVendas(GetVendasQuery request)
        {
            var query = _context.Venda.AsQueryable();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdVenda));

            if (request.DataInicio != null)
                query = query.Where(e => e.DataVenda >= (DateTime)request.DataInicio);

            if (request.DataFim != null)
                query = query.Where(e => e.DataVenda <= (DateTime)request.DataFim);

            var paginacao = request.Paginacao ?? new PaginacaoViewModel(PaginacaoConstants.PaginaDefault, PaginacaoConstants.ItensPorPaginaDefault);

            var resultado = query.Skip((paginacao.Pagina - 1) * paginacao.ItensPorPagina).Take(paginacao.ItensPorPagina).Count();

            return resultado;
        }
    }
}
