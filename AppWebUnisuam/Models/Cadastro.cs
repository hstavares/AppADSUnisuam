using System.ComponentModel.DataAnnotations;

namespace AppWebUnisuam.Models
{
    public class Cadastro
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();
        public string Nome { get; set; }
        public DateTime DataNascimento{ get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
        public string Bairro{ get; set; }
    }
}
