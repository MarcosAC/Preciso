using Preciso.Data.Model;

namespace Preciso.Data.LocalData.Repositorio
{
    public class RepositorioProfissional : IRepositorioProfissional
    {
        private readonly DbLocal _dbLocal;

        public RepositorioProfissional(DbLocal dbLocal)
        {
            _dbLocal = dbLocal;
        }

        public void AdicionarFuncionario(Profissional profissional)
        {
            _dbLocal.AdicionarProfissional(profissional);
        }

        public Profissional ObterProfissional(string email)
        {
            return _dbLocal.ObterProfssional(email);
        }
    }
}
