using System.Globalization;
using AgendaMed.Business.Genericos;

namespace AgendaMed.Models
{
    public class PessoaModel
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Sobrenome { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? CPF { get; set; }
        public string? DocProfissional { get; set; }
        public DateTime DataNascimento { get; set; }
        //public DateTime BirthDate { get; set; } =
        //    DateTime.ParseExact("01/01/1900", "dd/mm/yyyy", CultureInfo.InvariantCulture);
        public string? Telefone { get; set; }
    }
}