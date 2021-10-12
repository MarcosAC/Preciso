using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Cliente.DTOs;
using Preciso.Cliente.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Cliente.Data
{
    public class SolicitarServicoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task SolicitarServico(Servico servico) =>
            await firebase.Child("Servicos").PostAsync<Servico>(servico);

        public async Task<List<UsuarioDTO>> ListaUsuarios()
        {
            return (await firebase
                .Child("Usuarios")
                .OnceAsync<UsuarioDTO>()).Select(item => new UsuarioDTO
                {
                    Id = item.Object.Id,
                    Nome = item.Object.Nome
                })
                .ToList();
        }

        public async Task<UsuarioDTO> ObterUsuarioPorNome(string nome)
        {
            var usuarios = await ListaUsuarios();

            await firebase
              .Child("Usuarios")
              .OnceAsync<UsuarioDTO>();

            return usuarios.Where(usuario => usuario.Nome == nome).FirstOrDefault();
        }

        public async Task<List<ServicoDTO>> ListaServicos()
        {
            var lista =  (await firebase
                .Child("Servicos")
                .OnceAsync<ServicoDTO>()).Select(item => new ServicoDTO
                {
                    IdServico = item.Object.IdServico,
                    //ContatoCliente = item.Object.ContatoCliente,
                    //NomeCliente = item.Object.NomeCliente
                })
                .ToList();

            return lista;
        }

        public async Task CancelarServico(string id)
        {
            //var servicos = ListaServicos();

            var deletarServico = (await firebase
                .Child("Servicos")
                .OnceAsync<ServicoDTO>())
                .Where(ServicoDto => ServicoDto.Object.IdServico == id).FirstOrDefault();

            await firebase.Child("Servicos").Child(deletarServico.Key).DeleteAsync();
        }

        public ObservableCollection<Servico> ListaServicosSolicitados()
        {
            return firebase
                   .Child("Servicos")
                   .AsObservable<Servico>()
                   .AsObservableCollection();
        }
    }
}
