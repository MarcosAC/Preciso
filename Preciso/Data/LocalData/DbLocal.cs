using Preciso.Models;
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
    }
}
