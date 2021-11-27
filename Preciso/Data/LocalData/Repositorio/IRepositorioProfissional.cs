using Preciso.Data.Model;

namespace Preciso.Data.LocalData.Repositorio
{
    public interface IRepositorioProfissional
    {
        void AdicionarFuncionario(Profissional profissional);
        Profissional ObterProfissional(string email);
    }
}
