using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class FirebaseService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public ObservableCollection<Servico> Servicos { get; set; }

        public FirebaseService()
        {
            Servicos = ListaServicos();
        }

        public async Task CadastrarProfissional(Profissional profissional) => 
            await firebase.Child("Profissionais").PostAsync<Profissional>(profissional);        

        public async Task DeletarProfissional(int id)
        {
            var deletarServico = (await firebase
                .Child("Profissionais")
                .OnceAsync<Profissional>())
                .Where(profissional => profissional.Object.Id == id)
                .FirstOrDefault();

            await firebase
                .Child("Profissionais")
                .Child(deletarServico.Key)
                .DeleteAsync();
        }

        public ObservableCollection<Servico> ListaServicos()
        {
            return firebase
                   .Child("Servicos")
                   .AsObservable<Servico>()
                   .AsObservableCollection();
        }
    }
}
