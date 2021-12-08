using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class ConsultaTreinadorController : Notify
    {
        public ConsultaTreinadorController()
        {
            L_Treinador = new ObservableCollection<Treinador>();
        }

        private ObservableCollection<Treinador> l_Treinador;
        public ObservableCollection<Treinador> L_Treinador
        {
            get => l_Treinador;
            set { l_Treinador = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Treinador")); }
        }

        internal ObservableCollection<Treinador> TrazerListaTreinador()
        {
           return DAOTreinador.Instance.TrazerTreinadores();
        }
    }
}
