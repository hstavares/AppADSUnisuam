namespace AppWebUnisuam.DTO
{
    public class VendaPOST
    {
        public string Nome { get; set; }
        public string Cliente { get; set; }
        public string Funcionario { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double? Desconto { get; set; }
        public string FormaDePagamento { get; set; }
        public string Observacoes { get; set; }
        public double PrecoFinal { get; set; }
        public string? Imagem { get; set; }

        
    }
}
