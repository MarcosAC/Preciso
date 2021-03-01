using Firebase.Database;
using Firebase.Database.Query;
using Preciso.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Preciso.Data
{
    public class FirebasePrecisoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public ObservableCollection<Servico> Servicos { get; set; }

        public FirebasePrecisoService()
        {
            Servicos = ListaServicos();
        }

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

        public async Task<Servico> ObterServico(int id)
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

        public async Task<Profissional> VerificaLogin(string email)
        {
            var profissionais = await ListaProfissionais();

            await firebase
                  .Child("Profissionais")
                  .OnceAsync<Profissional>();

            return profissionais.Where(profissional => profissional.Email == email).FirstOrDefault();
        }
    }
}
