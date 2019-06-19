namespace CBVinil.Application.Paginacoes.Models
{
    public class PaginacaoViewModel
    {
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }

        public PaginacaoViewModel(int pagina, int itensPorPagina)
        {
            Pagina = pagina;
            ItensPorPagina = itensPorPagina;
        }
    }
}
