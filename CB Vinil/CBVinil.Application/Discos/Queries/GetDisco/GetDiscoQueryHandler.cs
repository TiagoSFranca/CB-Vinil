using AutoMapper;
using CBVinil.Application.Discos.Models;
using CBVinil.Application.Exceptions;
using CBVinil.Domain.Entities;
using CBVinil.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.Discos.Queries.GetDisco
{
    public class GetDiscoQueryHandler : IRequestHandler<GetDiscoQuery, DiscoViewModel>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public GetDiscoQueryHandler(CBVinilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiscoViewModel> Handle(GetDiscoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Disco.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Disco), request.Id);

            var item = _mapper.Map<DiscoViewModel>(entity);

            return item;
        }
    }
}
