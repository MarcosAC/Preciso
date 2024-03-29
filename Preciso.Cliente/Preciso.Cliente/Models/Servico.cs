﻿using System;
using Xamarin.Forms;

namespace Preciso.Cliente.Models
{
    public class Servico
    {
        public Servico()
        {
            IdServico = Guid.NewGuid();
        }

        public Guid IdServico { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string NomeCliente { get; set; }
        public string ContatoCliente { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public ImageSource Foto { get; set; }
        public string CaminhoFoto { get; set; }        
    }
}
