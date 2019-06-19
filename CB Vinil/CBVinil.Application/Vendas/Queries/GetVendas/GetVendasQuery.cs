using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CBVinil.Application.Vendas.Queries.GetVendas
{
    public class GetVendasQuery : IRequest<ConsultaPaginadaViewModel<VendaViewModel>>
    {
        public List<int> Ids { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public PaginacaoViewModel Paginacao { get; set; }
    }
}
