using CBVinil.Application.Discos.Models;
using MediatR;

namespace CBVinil.Application.Discos.Queries.GetDisco
{
    public class GetDiscoQuery : IRequest<DiscoViewModel>
    {
        public int Id { get; set; }
    }
}
