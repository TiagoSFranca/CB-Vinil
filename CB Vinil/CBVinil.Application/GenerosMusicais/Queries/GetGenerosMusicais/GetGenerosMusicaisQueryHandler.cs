using AutoMapper;
using CBVinil.Application.GenerosMusicais.Models;
using CBVinil.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.GenerosMusicais.Queries.GetGenerosMusicais
{
    public class GetGenerosMusicaisQueryHandler : IRequestHandler<GetGenerosMusicaisQuery, List<GeneroMusicalViewModel>>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public GetGenerosMusicaisQueryHandler(CBVinilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GeneroMusicalViewModel>> Handle(GetGenerosMusicaisQuery request, CancellationToken cancellationToken)
        {
            var query = _context.GeneroMusical.AsQueryable();

            if (request.Ids?.Count > 0)
                query = query.Where(e => request.Ids.Contains(e.IdGeneroMusical));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            if (!string.IsNullOrEmpty(request.Descricao))
                query = query.Where(e => e.Descricao.ToLower().Contains(request.Descricao.ToLower()));

            var resultado = await query.ToListAsync();

            return _mapper.Map<List<GeneroMusicalViewModel>>(resultado);
        }
    }
}
