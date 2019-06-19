using CBVinil.Application.Discos.Models;
using CBVinil.Application.Paginacoes.Models;
using MediatR;
using System.Collections.Generic;

namespace CBVinil.Application.Discos.Queries.GetDiscos
{
    public class GetDiscosQuery : IRequest<ConsultaPaginadaViewModel<DiscoViewModel>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
        public List<int> IdGenerosMusicais { get; set; }
        public string NomeGeneroMusical { get; set; }
        public PaginacaoViewModel Paginacao { get; set; }
    }
}
