using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class ConsultaExercicioController : Notify
    {
        public ConsultaExercicioController()
        {
            L_Exercicio = new ObservableCollection<Exercicio>();
        }

        private ObservableCollection<Exercicio> l_Exercicio;
        public ObservableCollection<Exercicio> L_Exercicio
        {
            get => l_Exercicio;
            set { l_Exercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Exercicio")); }
        }


        internal ObservableCollection<Exercicio> TrazerListaExercicio()
        {
            return DAOExercicio.Instance.TrazerExercicios();
        }
    }
}
