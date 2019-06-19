using CBVinil.Application.GenerosMusicais.Models;

namespace CBVinil.Application.Discos.Models
{
    public class DiscoViewModel
    {
        public int IdDisco { get; set; }
        public int IdGeneroMusical { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Artistas { get; set; }

        public GeneroMusicalViewModel GeneroMusical { get; set; }
    }
}
