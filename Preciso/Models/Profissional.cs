﻿using System;

namespace Preciso.Models
{
    public class Profissional
    {
        public Profissional()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }        
        public string Celular { get; set; }        
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        public string TipoProfissional { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }        
        public bool Ativo { get; set; }
        public DateTime DataAtivacao { get; set; }
        public DateTime DataDesativado { get; set; }        
    }
}
