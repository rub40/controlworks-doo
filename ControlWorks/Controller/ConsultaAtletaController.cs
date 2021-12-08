using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class ConsultaAtletaController : Notify
    {
        public ConsultaAtletaController()
        {
            L_Atleta = new ObservableCollection<Atleta>();
        }

        private ObservableCollection<Atleta> l_Atleta;
        public ObservableCollection<Atleta> L_Atleta
        {
            get => l_Atleta;
            set { l_Atleta = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Atleta")); }
        }

        internal ObservableCollection<Atleta> TrazerListaAtleta()
        {
            return DAOAtleta.Instance.TrazerAtletas();
        }
    }
}
