using CBVinil.Application.GenerosMusicais.Models;
using MediatR;
using System.Collections.Generic;

namespace CBVinil.Application.GenerosMusicais.Queries.GetGenerosMusicais
{
    public class GetGenerosMusicaisQuery : IRequest<List<GeneroMusicalViewModel>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
    }
}
