using Preciso.Cliente.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Preciso.Cliente.ViewModels
{
    public class CadastroClienteViewModel : BaseViewModel
    {
        private readonly FirebaseService firebase;

        public CadastroClienteViewModel()
        {
            firebase = new FirebaseService();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _endereco;
        public string Endereco
        { 
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }

        private string _celular;
        public string Celular
        { 
            get => _celular;
            set => SetProperty(ref _celular, value);
        }

        private string _email;
        public string Email
        { 
            get => _email;
            set => SetProperty(ref _email, value);
        }
    }
}
