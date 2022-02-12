using Preciso.Data.Model;
using System.Collections.Generic;

namespace Preciso.Data.LocalData.Repositorio
{
    public class RepositorioProfissional : IRepositorioProfissional
    {
        private readonly DbLocal _dbLocal;

        public RepositorioProfissional()
        {
            _dbLocal = new DbLocal();
        }

        public void AdicionarFuncionario(Profissional profissional)
        {
            if (ObterProfissional(profissional.Email) == null)
                _dbLocal.AdicionarProfissional(profissional);
        }

        public List<Profissional> ListaProfissionais()
        {
            return _dbLocal.ListaProfissionais();
        }

        public Profissional ObterProfissional(string email)
        {
            return _dbLocal.ObterProfssional(email);
        }
    }
}
