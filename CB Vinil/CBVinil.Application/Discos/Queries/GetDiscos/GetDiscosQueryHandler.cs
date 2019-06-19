using AutoMapper;
using CBVinil.Application.Discos.Models;
using CBVinil.Application.Paginacoes.Models;
using CBVinil.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.Discos.Queries.GetDiscos
{
    public class GetDiscosQueryHandler : IRequestHandler<GetDiscosQuery, ConsultaPaginadaViewModel<DiscoViewModel>>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public GetDiscosQueryHandler(CBVinilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConsultaPaginadaViewModel<DiscoViewModel>> Handle(GetDiscosQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Disco.AsQueryable();
            query = query.OrderBy(e => e.Nome);

            var totalItens = await query.CountAsync();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdDisco));

            if (request.IdGenerosMusicais?.Count > 0)
                query = query.Where(e => request.IdGenerosMusicais.Contains(e.IdGeneroMusical));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            if (!string.IsNullOrEmpty(request.NomeGeneroMusical))
                query = query.Where(e => e.GeneroMusical.Nome.ToLower().Contains(request.NomeGeneroMusical.ToLower()));

            var paginacao = request.Paginacao ?? new PaginacaoViewModel(1, 10);

            var resultado = await query.Skip((paginacao.Pagina - 1) * paginacao.ItensPorPagina).Take(paginacao.ItensPorPagina).ToListAsync();

            var resultadoMapeado = _mapper.Map<List<DiscoViewModel>>(resultado);

            var retorno = new ConsultaPaginadaViewModel<DiscoViewModel>(paginacao.Pagina, paginacao.ItensPorPagina)
            {
                TotalItens = totalItens,
                Itens = resultadoMapeado
            };

            return retorno;
        }
    }
}
