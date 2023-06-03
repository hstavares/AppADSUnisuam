namespace AppWebUnisuam.Models
{
    public class Vendas
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DataDaVenda { get; set; } = DateTime.Now;
        public string Produto { get; set; }
        public string Cliente { get; set; }
        public string Quantidade { get; set; }
        public string PrecoUnitario { get; set; }
        public string ValorDaVenda { get; set; }
        public string? Desconto { get; set; }
        public string Funcionario { get; set; }
        public string FormaDePagamento { get; set; }
        public string? Observacoes { get; set; }
    }
}
