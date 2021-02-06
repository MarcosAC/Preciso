using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Cliente.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Cliente.Data
{
    public class FirebaseService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task SolicitarServico(Servico servico) => await firebase.Child("Servicos").PostAsync<Servico>(servico);

        public async Task DeletarServico(int id)
        {
            var deletarServico = (await firebase
                .Child("Servicos")
                .OnceAsync<Servico>())
                .Where(servico => servico.Object.Id == id)
                .FirstOrDefault();

            await firebase
                .Child("Servicos")
                .Child(deletarServico.Key)
                .DeleteAsync();
        }
    }
}
