using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Cliente.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Cliente.Data
{
    public class ServicoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task SolicitarServico(Servico servico) =>
            await firebase.Child("Servicos").PostAsync<Servico>(servico);

        public async Task<Servico> ObterServico(string id)
        {
            ObservableCollection<Servico> servicos = ListaServicos();

            await firebase
              .Child("Servicos")
              .OnceAsync<Servico>();
            return servicos.Where(servico => servico.Id == id).FirstOrDefault();
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
