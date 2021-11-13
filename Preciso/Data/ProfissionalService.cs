using Firebase.Database;
using Firebase.Database.Query;
using Preciso.DTOs;
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

        public async Task EditarProfissional(ProfissionalDTO profissionalDTO)
        {
            var toUpdateContato = (await firebase
             .Child("Profissionais")
               .OnceAsync<ProfissionalDTO>())
                  .Where(profissional => profissional.Object.Id == profissionalDTO.Id).FirstOrDefault();
            await firebase
              .Child("Profissionais")
                .Child(toUpdateContato.Key)
                  .PutAsync(new ProfissionalDTO()
                  {
                      Nome = profissionalDTO.Nome,
                      Cpf = profissionalDTO.Cpf,
                      Celular = profissionalDTO.Celular,
                      Endereco = profissionalDTO.Endereco,
                      FormaPagamento = profissionalDTO.FormaPagamento,
                      TipoProfissional = profissionalDTO.TipoProfissional,
                      Email = profissionalDTO.Email
                  });
    }

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

        //public async Task<List<Profissional>> ListaProfissionais()
        //{
        //    return (await firebase
        //      .Child("Profissionais")
        //      .OnceAsync<Profissional>()).Select(item => new Profissional
        //      {
        //          Id = item.Object.Id,
        //          Email = item.Object.Email,
        //          Senha = item.Object.Senha
        //      }).ToList();
        //}

        public async Task<List<ProfissionalDTO>> ListaProfissionais()
        {
            return (await firebase
                .Child("Profissionais")
                .OnceAsync<ProfissionalDTO>()).Select(item => new ProfissionalDTO
                {
                    Id = item.Object.Id
                })
                .ToList();
        }
    }
}
