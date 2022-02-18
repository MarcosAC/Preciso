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
        private readonly FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        public async Task CadastrarProfissional(Profissional profissional) =>
            await firebase.Child("Profissionais").PostAsync(profissional);

        public async Task EditarProfissional(ProfissionalDto profissionalDTO)
        {
            var toUpdateContato = (await firebase
             .Child("Profissionais")
               .OnceAsync<ProfissionalDto>())
                  .Where(profissional => profissional.Object.Id == profissionalDTO.Id).FirstOrDefault();
            await firebase
              .Child("Profissionais")
                .Child(toUpdateContato.Key)
                  .PutAsync(new ProfissionalDto()
                  {
                      Id = profissionalDTO.Id,
                      Nome = profissionalDTO.Nome,
                      Cpf = profissionalDTO.Cpf,
                      Celular = profissionalDTO.Celular,
                      Endereco = profissionalDTO.Endereco,
                      FormaPagamento = profissionalDTO.FormaPagamento,
                      TipoProfissional = profissionalDTO.TipoProfissional,
                      Email = profissionalDTO.Email,
                      Senha = profissionalDTO.Senha,
                      Ativo = profissionalDTO.Ativo,
                      DataAtivacao = profissionalDTO.DataAtivacao,
                      DataDesativado = profissionalDTO.DataDesativado                      
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

        public async Task<List<ProfissionalDto>> ListaProfissionais()
        {
            return (await firebase
                .Child("Profissionais")
                .OnceAsync<ProfissionalDto>()).Select(item => new ProfissionalDto
                {
                    Id = item.Object.Id,
                    Nome = item.Object.Nome,
                    Cpf = item.Object.Cpf,
                    Celular = item.Object.Celular,
                    Endereco = item.Object.Endereco,
                    FormaPagamento = item.Object.FormaPagamento,
                    TipoProfissional = item.Object.TipoProfissional,
                    Email = item.Object.Email,
                    Senha = item.Object.Senha,
                    Ativo = item.Object.Ativo,
                    DataAtivacao = item.Object.DataAtivacao,
                    DataDesativado = item.Object.DataDesativado
                })
                .ToList();
    }

        public async Task<ProfissionalDto> VerificaLogin(string email)
        {
            var profissionais = await ListaProfissionais();

            await firebase
                  .Child("Usuarios")
                  .OnceAsync<Profissional>();

            return profissionais.Where(profissional => profissional.Email == email).FirstOrDefault();
        }
    }
}
