using CBVinil.Application.Vendas.Models;
using MediatR;
using System.Collections.Generic;

namespace CBVinil.Application.Vendas.Commands.VenderDiscos
{
    public class VenderDiscosCommand : IRequest<VendaViewModel>
    {
        public List<VenderDiscoViewModel> Discos { get; set; }
    }
}
