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
    public class PrecisoService
    {
        FirebaseClient firebase = new FirebaseClient("https://presicoapp-default-rtdb.firebaseio.com/");

        //public async Task<Servico> ObterServico(int id)
        //{
        //    var servicos = await ListaServicos();

        //     await firebase
        //           .Child("Servicos")
        //           .OnceAsync<Servico>();
        //    return servicos.Where(servico => servico.Id == id).FirstOrDefault();
        //}

        //public async Task<List<Servico>> ListaServicos()
        //{
        //    var lista = (await firebase
        //                  .Child("Servicos")
        //                  .OnceAsync<Servico>()).Select(item => new Servico
        //                  {
        //                      Titulo = item.Object.Titulo,
        //                      Descricao = item.Object.Descricao
        //                  }).ToList();

        //    return lista;
        //}
    }
}
