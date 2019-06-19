using CBVinil.Application.GenerosMusicais.Queries.GetGenerosMusicais;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBVinil.API.Controllers
{
    public class GenerosMusicaisController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]List<int> ids, [FromQuery]string nome, [FromQuery]string descricao)
        {
            GetGenerosMusicaisQuery query = new GetGenerosMusicaisQuery()
            {
                Ids = ids,
                Nome = nome,
                Descricao = descricao
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
