using CBVinil.Application.GenerosMusicais.Queries.GetGenerosMusicais;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBVinil.API.Controllers
{
    public class GenerosMusicaisController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]List<int> ids, [FromQuery]string nome)
        {
            GetGenerosMusicaisQuery query = new GetGenerosMusicaisQuery()
            {
                Ids = ids,
                Nome = nome
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
