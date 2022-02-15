using System.Collections.Generic;
using System.IO;

namespace Preciso.Data.Repository
{
    public interface IRepository
    {
        //void Adicionar<T>(T model) where T : class;
        //void Editar<T>(T model) where T : class;
        //void Deletar<T>(T model) where T : class;
        //void SelecionarPorId<T>(T model) where T : class;
        //List<T> Listar<T>(T model) where T : class;
        void AdicionarServico(Stream streamFoto, string nomeFoto);
    }
}
