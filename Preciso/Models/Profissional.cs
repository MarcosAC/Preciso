using System;

namespace Preciso.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        public TipoProfissional TipoProfissional { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtivacao { get; set; }
        public DateTime DataDesativado { get; set; }
    }
}
