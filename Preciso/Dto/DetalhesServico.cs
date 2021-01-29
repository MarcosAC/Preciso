using Preciso.Models;
using System.Collections.ObjectModel;

namespace Preciso.Dto
{
    public class DetalhesServico
    {
        private ObservableCollection<Servico> Servicos { get; set; }

        public ObservableCollection<Servico> ListaServicos()
        {
            return Servicos;
        }
    }
}
