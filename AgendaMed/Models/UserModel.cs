using AgendaMed.Business.Genericos;

namespace AgendaMed.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public virtual PessoaModel? Pessoa { get; set; }
        public string? Password { get; set; }
        public string? Nickname { get; set; }
        public AccessType AccessType { get; set; }
    }
}
