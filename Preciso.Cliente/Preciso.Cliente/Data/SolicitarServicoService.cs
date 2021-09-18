using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Cliente.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Cliente.Data
{
    public class SolicitarServicoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task SolicitarServico(Servico servico) =>
            await firebase.Child("Servicos").PostAsync<Servico>(servico);

        public async Task<List<Usuario>> ListaUsuarios()
        {
            return (await firebase
             .Child("Usuarios")
             .OnceAsync<Usuario>()).Select(item => new Usuario
             {
                 Id = item.Object.Id,
             })
             .ToList();
        }

        public async Task<Usuario> ObterUsuarioPorNome(string nome)
        {
            var usuarios = await ListaUsuarios();

            await firebase
              .Child("Servicos")
              .OnceAsync<Servico>();

            return usuarios.Where(usuario => usuario.Nome == nome).FirstOrDefault();
        }
    }
}
