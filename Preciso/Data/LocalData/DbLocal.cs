using Preciso.Data.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Preciso.Data.LocalData
{
    public class DbLocal
    {
        private static SQLiteConnection _conexao;

        public DbLocal()
        {
            var dependencyService = DependencyService.Get<IConexaoDbLocal>();
            string stringConexao = dependencyService.Conexao("dbLocal.sqlite");

            _conexao = new SQLiteConnection(stringConexao);
            _conexao.CreateTable<Profissional>();
        }

        public void AdicionarProfissional(Profissional profissional)
        {
            _conexao.Insert(profissional);
        }

        public Profissional ObterProfssional(string email)
        {
            return _conexao.Table<Profissional>().FirstOrDefault(profissional => profissional.Email == email);
        }
    }
}
