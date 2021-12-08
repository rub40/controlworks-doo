using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class TreinadorController : Notify
    {
        public TreinadorController()
        {
            TelaDados = new U_TreinadorDados(this);
            CurrentTreinador = new Treinador();
            L_Treinador = new ObservableCollection<Treinador>();
        }

        private U_TreinadorDados telaDados;
        public U_TreinadorDados TelaDados
        {
            get => telaDados;
            set { telaDados = value; OnPropertyChanged(new PropertyChangedEventArgs("TelaDados")); }
        }

        private Treinador currentTreinador;
        public Treinador CurrentTreinador
        {
            get => currentTreinador;
            set { currentTreinador = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentTreinador")); }
        }

        private ObservableCollection<Treinador> l_treinador;
        public ObservableCollection<Treinador> L_Treinador
        {
            get => l_treinador;
            set { l_treinador = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Treinador")); }
        }

        internal void SalvarTreinador()
        {
            DAOTreinador.Instance.ValidarDadosTreinador(CurrentTreinador);
        }

        internal ObservableCollection<Treinador> TrazerListaTreinador()
        {
            return DAOTreinador.Instance.TrazerTreinadores();
        }

        internal Treinador BuscarTreinador(string v)
        {
            return DAOTreinador.Instance.TrazerTreinador(v);
        }
    }
}
