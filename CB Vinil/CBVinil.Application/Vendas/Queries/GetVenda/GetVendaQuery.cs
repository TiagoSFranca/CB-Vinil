using CBVinil.Application.Vendas.Models;
using MediatR;

namespace CBVinil.Application.Vendas.Queries.GetVenda
{
    public class GetVendaQuery : IRequest<VendaViewModel>
    {
        public int Id { get; set; }
    }
}
