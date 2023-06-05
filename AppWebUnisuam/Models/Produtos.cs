using System.ComponentModel.DataAnnotations;

namespace AppWebUnisuam.Models
{
    public class Produtos
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string? Descrição { get; set; }
        public string Preco { get; set; }
        public string? Categoria { get; set; }
        public string? Marca { get; set; }
        public string? Imagem { get; set; }
        public string? Disponibilidade { get; set;}
        public int Estoque { get; set; }
        public DateTime AtualizadoEm { get;set; } = DateTime.Now;
        public DateTime CriadoEm { get;set; } = DateTime.Now;
    }
}
