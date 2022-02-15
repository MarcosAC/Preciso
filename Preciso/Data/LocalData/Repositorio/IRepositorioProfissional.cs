using Preciso.Data.Model;
using System.Collections.Generic;

namespace Preciso.Data.LocalData.Repositorio
{
    public interface IRepositorioProfissional
    {
        void AdicionarFuncionario(Profissional profissional);
        Profissional ObterProfissional(string email);
        List<Profissional> ListaProfissionais();
    }
}
