using Firebase.Database;
using Preciso.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class ServicoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task<Servico> ObterServico(string id)
        {
            var servicos = ListaServicos();

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
