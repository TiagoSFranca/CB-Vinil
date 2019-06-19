using AutoMapper;
using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Models;
using CBVinil.Common.Constants;
using CBVinil.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.Vendas.Queries.GetVendas
{
    public class GetVendasQueryHandler : IRequestHandler<GetVendasQuery, ConsultaPaginadaViewModel<VendaViewModel>>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public GetVendasQueryHandler(CBVinilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConsultaPaginadaViewModel<VendaViewModel>> Handle(GetVendasQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Venda.AsQueryable();
            query = query.OrderByDescending(e => e.DataVenda);

            var totalItens = await query.CountAsync();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdVenda));

            if (request.DataInicio != null)
                query = query.Where(e => e.DataVenda >= (DateTime)request.DataInicio);

            if (request.DataFim != null)
                query = query.Where(e => e.DataVenda <= (DateTime)request.DataFim);

            var paginacao = request.Paginacao ?? new PaginacaoViewModel(PaginacaoConstants.PaginaDefault, PaginacaoConstants.ItensPorPaginaDefault);

            var resultado = await query.Skip((paginacao.Pagina - 1) * paginacao.ItensPorPagina).Take(paginacao.ItensPorPagina).ToListAsync();

            var resultadoMapeado = _mapper.Map<List<VendaViewModel>>(resultado);

            var retorno = new ConsultaPaginadaViewModel<VendaViewModel>(paginacao.Pagina, paginacao.ItensPorPagina)
            {
                TotalItens = totalItens,
                Itens = resultadoMapeado
            };

            return retorno;
        }
    }
}
