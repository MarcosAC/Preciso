using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class FirebaseStorageService
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("gs://presicoapp.appspot.com");

        public async Task AdicionarFoto(Stream streamFoto, string nomeFoto)
        {
            if (streamFoto == null)
            {
                return;
            }

            await firebaseStorage
                .Child("NomeCliente")
                .Child("ContatoCliente")
                .Child("Titulo")
                .Child("Descricao")
                .Child(nomeFoto)
                .PutAsync(streamFoto);
        }
    }
}
