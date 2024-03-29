﻿using Preciso.Cliente.Data;
using Preciso.Cliente.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.Cliente.ViewModels
{
    public class SolicitarServicoViewModel : BaseViewModel
    {
        //FirebaseStorageService firebaseStorageService = new FirebaseStorageService();
        //private FileResult foto;

        private readonly SolicitarServicoService solicitarServicoService;

        public SolicitarServicoViewModel()
        {
            solicitarServicoService = new SolicitarServicoService();
        }

        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _idUsuario;

        public string IdUsuario 
        {
            get => _idUsuario;
            set => SetProperty(ref _idUsuario, value);
        }

        //private DateTime _dataSolicitacao;
        //public DateTime DataSolicitacao 
        //{ 
        //    get => _dataSolicitacao;
        //    set => SetProperty(ref _dataSolicitacao, value);
        //}

        private string _nomeCliente;
        public string NomeCliente
        { 
            get => _nomeCliente; 
            set => SetProperty(ref _nomeCliente, value);
        }

        private string _contatoCliente;
        public string ContatoCliente
        { 
            get => _contatoCliente;
            set => SetProperty(ref _contatoCliente, value);
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

        private ImageSource _foto;
        public ImageSource Foto
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
            _enviarSolicitacaoServicoCommand ?? (_enviarSolicitacaoServicoCommand = new Command(async () => await ExecuteEnviarSolicitacaoServicoCommand()));

        private async Task ExecuteEnviarSolicitacaoServicoCommand()
        {
            //if (foto == null)
            //{
            //    await App.Current.MainPage.DisplayAlert("", "Erro", "Ok");
            //}
            //else
            //{
            //    var stream = await foto.OpenReadAsync();
            //    await firebaseStorageService.AdicionarFoto(stream, foto.FileName);
            //}

            var usuario = await solicitarServicoService.ObterUsuarioPorNome(NomeCliente);

            var servico = new Servico
            {
                IdUsuario = usuario.Id.ToString(),
                NomeCliente = NomeCliente,
                ContatoCliente = ContatoCliente,
                Titulo = Titulo,
                Descricao = Descricao
            };

            if (servico != null)
            {
                await solicitarServicoService.SolicitarServico(servico);
                await App.Current.MainPage.DisplayAlert("Cadastrar Serviço", "Sucesso ao cadastrar serviço", "Ok");                
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Cadastrar Serviço", "Erro ao cadastrar serviço", "Ok");
            }
        }

        private Command _cancelarSolicitacaoServicoCommand;
        public Command CancelarSolicitacaoServicoCommand =>
            _cancelarSolicitacaoServicoCommand ?? (_cancelarSolicitacaoServicoCommand = new Command(async () => await ExecuteCancelarSolicitacaoServicoCommand(Id)));

        private async Task ExecuteCancelarSolicitacaoServicoCommand(Guid id)
        {
            //await servicoService.CancelarServico(id);
        }

        #region Funções de Inserir Foto
        //private Command _adicionarFotoCommand;
        //public Command AdicionarFotoCommand => 
        //    _adicionarFotoCommand ?? (_adicionarFotoCommand = new Command(async () => await ExecuteAdicionarFotoCommand(), () => MediaPicker.IsCaptureSupported));

        //private async Task ExecuteAdicionarFotoCommand()
        //{
        //    if (!await App.Current.MainPage.DisplayAlert("Adicionar Imagem ou Foto",
        //                                                 "Deseja adicionar uma imagem do arquivo ou tirar uma foto?",
        //                                                 "Adicionar Foto do Arquivo", "Tirar Foto"))
        //    {
        //        foto = await MediaPicker.CapturePhotoAsync();
        //        await CarregarFotoAsync(foto);
        //    }
        //    else
        //    {
        //        foto = await MediaPicker.PickPhotoAsync();
        //        await CarregarFotoAsync(foto);
        //    }
        //}

        //private async Task CarregarFotoAsync(FileResult foto)
        //{
        //    var arquivoFoto = Path.Combine(FileSystem.CacheDirectory, foto.FileName);

        //    using (var stream = await foto.OpenReadAsync())
        //    using (var novoStream = File.OpenWrite(arquivoFoto))
        //    {
        //        await stream.CopyToAsync(novoStream);
        //        Foto = ImageSource.FromFile(arquivoFoto);
        //    }
        //}

        //private void CarregarFoto(FileResult foto)
        //{
        //    var arquivoFoto = Path.Combine(FileSystem.CacheDirectory/*, foto.FileName*/);

        //    //using (var stream = foto.OpenReadAsync())
        //    using (var novoStream = File.OpenWrite(arquivoFoto))
        //    {
        //        Foto = ImageSource.FromStream(() =>
        //        {
        //            var streamFoto = File.Open(arquivoFoto, FileMode.Open);
        //            return streamFoto;
        //        });
        //        //return novoStream;
        //    }
        //}
        #endregion
    }
}
