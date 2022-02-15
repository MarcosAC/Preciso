using SQLite;

namespace Preciso.Data.Model
{
    [Table("Contato")]
    public class Profissional
    {
        //[PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        public string TipoProfissional { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
