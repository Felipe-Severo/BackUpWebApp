using AgendaMed.Business.Genericos;

namespace AgendaMed.Models
{
    public class ConsultaModel
    {
        public long Id { get; set; }
        public string? Medico { get; set; }
        public string? Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime HoraConsulta { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public string? Sintomas { get; set; }
        public string? Receita { get; set; }
        public string? Recomendacoes { get; set; }
        public string? Exames { get; set; }
    }
}
