using CBVinil.Application.Exceptions;
using CBVinil.Application.Paginacoes.Models;
using CBVinil.Application.Vendas.Commands.VenderDiscos;
using CBVinil.Application.Vendas.Models;
using CBVinil.Application.Vendas.Queries.GetVenda;
using CBVinil.Application.Vendas.Queries.GetVendas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CBVinil.API.Controllers
{
    public class VendasController : BaseController
    {
        [HttpPost("Vender")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VendaViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequestViewModel))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerErrorViewModel))]
        public async Task<ActionResult<VendaViewModel>> VenderDiscos(VenderDiscosCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaPaginadaViewModel<VendaViewModel>))]
        public async Task<ActionResult<ConsultaPaginadaViewModel<VendaViewModel>>> GetAll([FromQuery] List<int> ids, [FromQuery]DateTime? dataInicio,
            [FromQuery]DateTime? dataFim, [FromQuery] int? pagina, [FromQuery] int? itensPorPagina)
        {
            var query = new GetVendasQuery()
            {
                Ids = ids,
                DataFim = dataFim,
                DataInicio = dataInicio
            };

            if (pagina != null && itensPorPagina != null)
                query.Paginacao = new PaginacaoViewModel((int)pagina, (int)itensPorPagina);

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VendaViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFoundViewModel))]
        public async Task<ActionResult<VendaViewModel>> Get(int id)
        {
            var query = new GetVendaQuery() { Id = id };

            return Ok(await Mediator.Send(query));
        }
    }
}
