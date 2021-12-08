using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class AtletaController : Notify
    {
        public AtletaController()
        {
            TelaDados = new U_AtletaDados(this);
            CurrentAtleta = new Atleta();
            L_Atleta = new ObservableCollection<Atleta>();
        }

        private U_AtletaDados telaDados;
        public U_AtletaDados TelaDados
        {
            get => telaDados;
            set { telaDados = value; OnPropertyChanged(new PropertyChangedEventArgs("TelaDados")); }
        }

        private Atleta currentAtleta;
        public Atleta CurrentAtleta
        {
            get => currentAtleta;
            set { currentAtleta = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentAtleta")); }
        }

        private ObservableCollection<Atleta> l_atleta;
        public ObservableCollection<Atleta> L_Atleta
        {
            get => l_atleta;
            set { l_atleta = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Atleta")); }
        }

        internal ObservableCollection<Atleta> TrazerListaAtleta()
        {
            return DAOAtleta.Instance.TrazerAtletas();
        }

        internal void SalvarAtleta()
        {
            DAOAtleta.Instance.ValidaDadosAtleta(CurrentAtleta);
        }
    }
}
