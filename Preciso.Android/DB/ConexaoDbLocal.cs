using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Preciso.Data.LocalData;
using Preciso.Droid.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConexaoDbLocal))]
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