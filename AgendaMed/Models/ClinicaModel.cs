namespace AgendaMed.Models
{
    public class ClinicaModel
    {
        public long Id { get; set; }
        public PessoaModel? Responsavel { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Telefone { get; set; }
    }
}
