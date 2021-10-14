using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class ProfissionalService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task CadastrarProfissional(Profissional profissional) =>
            await firebase.Child("Profissionais").PostAsync(profissional);

        public async Task DeletarProfissional(Guid id)
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

        public async Task<List<Profissional>> ListaProfissionais()
        {
            return (await firebase
              .Child("Profissionais")
              .OnceAsync<Profissional>()).Select(item => new Profissional
              {
                  Email = item.Object.Email,
                  Senha = item.Object.Senha
              }).ToList();
        }
    }
}
