using CBVinil.Application.Discos.Models;
using CBVinil.Application.Discos.Queries.GetDisco;
using CBVinil.Application.Discos.Queries.GetDiscos;
using CBVinil.Application.Exceptions;
using CBVinil.Application.Paginacoes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CBVinil.API.Controllers
{
    public class DiscosController : BaseController
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaPaginadaViewModel<DiscoViewModel>))]
        public async Task<ActionResult<ConsultaPaginadaViewModel<DiscoViewModel>>> GetAll([FromQuery] List<int> ids, [FromQuery]List<int> idGeneros,
            [FromQuery]string nome, [FromQuery]string nomeGenero, [FromQuery] int? pagina, [FromQuery] int? itensPorPagina)
        {
            var query = new GetDiscosQuery()
            {
                Ids = ids,
                IdGenerosMusicais = idGeneros,
                Nome = nome,
                NomeGeneroMusical = nomeGenero
            };

            if (pagina != null && itensPorPagina != null)
                query.Paginacao = new PaginacaoViewModel((int)pagina, (int)itensPorPagina);

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DiscoViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFoundViewModel))]
        public async Task<ActionResult<DiscoViewModel>> Get(int id)
        {
            var query = new GetDiscoQuery() { Id = id };

            return Ok(await Mediator.Send(query));
        }
    }
}
