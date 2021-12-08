using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class ExericicioController : Notify
    {
        public ExericicioController()
        {
            TelaDados = new U_ExercicioDados(this);
            L_Exercicio = new ObservableCollection<Exercicio>();
            CurrentExercicio = new Exercicio();
        }

        private U_ExercicioDados telaDados;
        public U_ExercicioDados TelaDados
        {
            get => telaDados;
            set { telaDados = value; OnPropertyChanged(new PropertyChangedEventArgs("TelaDados")); }
        }

        private ObservableCollection<Exercicio> l_Exercicio;
        public ObservableCollection<Exercicio> L_Exercicio
        {
            get => l_Exercicio;
            set { l_Exercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Exercicio")); }
        }

        private Exercicio currentExercicio;
        public Exercicio CurrentExercicio
        {
            get => currentExercicio;
            set { currentExercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentExercicio")); }
        }

        internal ObservableCollection<Exercicio> TrazerListaTreinos()
        {
            return DAOExercicio.Instance.TrazerExercicios();
        }

        internal void SalvarTreino()
        {
            DAOExercicio.Instance.ValidarDadosExercicio(CurrentExercicio);
        }
    }
}
