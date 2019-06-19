using CBVinil.Application.Exceptions;
using CBVinil.Application.Vendas.Commands.VenderDiscos;
using CBVinil.Application.Vendas.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<VendaViewModel>> GirarRodaFortuna(VenderDiscosCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
