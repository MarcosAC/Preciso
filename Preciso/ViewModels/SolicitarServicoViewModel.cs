using Preciso.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Preciso.Profissional.ViewModels
{
    public class SolicitarServicoViewModel : BaseViewModel
    {
        private DateTime _dataSolicitacao;
        public DateTime DataSolicitacao 
        { 
            get => _dataSolicitacao;
            set => SetProperty(ref _dataSolicitacao, value);
        }
        private string _nome;
        public string Nome
        { 
            get => _nome; 
            set => SetProperty(ref _nome, value);
        }

        private string _contato;
        public string Contato 
        { 
            get => _contato;
            set => SetProperty(ref _contato, value);
        }

        private string _titulo;
        public string Titulo 
        { 
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private string _descricao;
        public string Descricao
        { 
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }

        private byte[] _foto;
        public byte[] Foto
        { 
            get => _foto;
            set => SetProperty(ref _foto, value);
        }

        private string _caminhoFoto;
        public string CaminhoFoto
        { 
            get => _caminhoFoto;
            set => SetProperty(ref _caminhoFoto, value);
        }

        private Command _enviarSolicitacaoServicoCommand;
        public Command EnviarSolicitacaoServicoCommand =>
            _enviarSolicitacaoServicoCommand ?? (_enviarSolicitacaoServicoCommand = new Command(async () => ExecuteEnviarSolicitacaoServicoCommand()));

        private async Task ExecuteEnviarSolicitacaoServicoCommand()
        {
            //TODO - Fazer API e camada de DataBase.
        }

        private Command _cancelarSolicitacaoServicoCommand;
        public Command CancelarSolicitacaoServicoCommand =>
            _cancelarSolicitacaoServicoCommand ?? (_cancelarSolicitacaoServicoCommand = new Command(async () => ExecuteCancelarSolicitacaoServicoCommand()));

        private async Task ExecuteCancelarSolicitacaoServicoCommand()
        {
            //TODO - Fazer API e camada de DataBase.
        }

        private Command _adicionarFotoCommand;
        public Command AdicionarTirarFotoCommand => 
            _adicionarFotoCommand ?? (_adicionarFotoCommand = new Command(async () => await ExecuteAdicionarFotoCommand(), () => MediaPicker.IsCaptureSupported));

        private async Task ExecuteAdicionarFotoCommand()
        {
            if (!await App.Current.MainPage.DisplayAlert("Adicionar Imagem ou Foto",
                                                         "Deseja adicionar uma imagem do arquivo ou tirar uma foto?",
                                                         "Adicionar Foto do Arquivo", "Tirar Foto"))
            {
                var foto = await MediaPicker.CapturePhotoAsync();
                await CarregarFotoAsync(foto);
            }
            else
            {
                var foto = await MediaPicker.PickPhotoAsync();
                await CarregarFotoAsync(foto);
            }
        }

        private async Task CarregarFotoAsync(FileResult foto)
        {
            var arquivoFoto = Path.Combine(FileSystem.CacheDirectory, foto.FileName);

            using (var stream = await foto.OpenReadAsync())
            using (var novoStream = File.OpenWrite(arquivoFoto))
            {
                await stream.CopyToAsync(novoStream);
            }
        }
    }
}
