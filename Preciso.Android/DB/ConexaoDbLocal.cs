using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Preciso.Data.LocalData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Preciso.Droid.DB
{
    public class ConexaoDbLocal : IConexaoDbLocal
    {
        public string Conexao(string nomeDb)
        {
            string stringConexao = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string bancoDadosLocal = Path.Combine(stringConexao, nomeDb);

            return bancoDadosLocal;
        }
    }
}