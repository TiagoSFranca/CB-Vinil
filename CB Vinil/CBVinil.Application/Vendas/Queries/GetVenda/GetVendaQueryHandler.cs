using AutoMapper;
using CBVinil.Application.Exceptions;
using CBVinil.Application.Vendas.Models;
using CBVinil.Domain.Entities;
using CBVinil.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CBVinil.Application.Vendas.Queries.GetVenda
{
    public class GetVendaQueryHandler : IRequestHandler<GetVendaQuery, VendaViewModel>
    {
        private readonly CBVinilContext _context;
        private readonly IMapper _mapper;

        public GetVendaQueryHandler(CBVinilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendaViewModel> Handle(GetVendaQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Venda.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Venda), request.Id);

            var item = _mapper.Map<VendaViewModel>(entity);

            return item;
        }
    }
}
