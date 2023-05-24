using System.ComponentModel.DataAnnotations;

namespace AppWebUnisuam.Models
{
    public class Cadastro
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public DateTime DataNascimento{ get; set; }
        public string Cidade { get; set; }
        public string Bairro{ get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
