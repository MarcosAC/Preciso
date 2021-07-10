using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Cliente.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Cliente.Data
{
    public class FirebaseUsuarioService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task CadastrarUsuario(Usuario usuario) =>
            await firebase.Child("Usuarios").PostAsync<Usuario>(usuario);

        public async Task Editar(Guid id)
        {
            var editarUsuario = (await firebase
                .Child("Usuarios")
                .OnceAsync<Usuario>())
                .Where(usuario => usuario.Object.Id == id)
                .FirstOrDefault();

            await firebase
                .Child("Usuarios")
                .Child(editarUsuario.Key)
                .DeleteAsync();
        }
    }
}
