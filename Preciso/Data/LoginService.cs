using Firebase.Database;
using Preciso.DTOs;
using Preciso.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class LoginService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        private readonly ProfissionalService profissionalService;

        public LoginService()
        {
            profissionalService = new ProfissionalService();
        }

        public async Task<ProfissionalDTO> VerificaLogin(string email)
        {
            var profissionais = await profissionalService.ListaProfissionais();

            await firebase
                  .Child("Profissionais")
                  .OnceAsync<Profissional>();

            return profissionais.Where(profissional => profissional.Email == email).FirstOrDefault();
        }
    }
}
