using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace Helpers.Data
{
    public class FirebaseService
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task SolicitarServico(object model) => await firebase.Child("Servicos").PostAsync(model);
    }
}
