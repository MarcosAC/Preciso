using System;

namespace Preciso.Cliente.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
