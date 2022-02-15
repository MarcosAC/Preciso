using System;

namespace Preciso.Models
{
    public class Servico
    {
        public string Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string NomeCliente { get; set; }
        public string ContatoCliente { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Byte[] Foto { get; set; }
        public string CaminhoFoto { get; set; }        
    }
}
