using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class LancamentoController : Notify
    {
        public LancamentoController()
        {
            CurrentTreino = new Treino();
            CurrentExercicio = new Exercicio();
            L_Treino = new ObservableCollection<Treino>();
            TelaDados = new U_LancamentoDados(this);
        }

        private Treino currentTreino;
        public Treino CurrentTreino
        {
            get { return currentTreino; }
            set { currentTreino = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentTreino")); }
        }

        private ObservableCollection<Treino> l_Treino;
        public ObservableCollection<Treino> L_Treino
        {
            get { return l_Treino; }
            set { l_Treino = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Treino")); }
        }

        private Exercicio currentExercicio;
        public Exercicio CurrentExercicio
        {
            get { return currentExercicio; }
            set { currentExercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentExercicio")); }
        }

        private U_LancamentoDados telaDados;
        public U_LancamentoDados TelaDados
        {
            get { return telaDados; }
            set { telaDados = value; OnPropertyChanged(new PropertyChangedEventArgs("TelaDados")); }
        }

        private bool tipoTreino; //Tempo = true / Fisico = false
        public bool TipoTreino
        {
            get { return tipoTreino; }
            set { tipoTreino = value; OnPropertyChanged(new PropertyChangedEventArgs("TipoTreino")); }
        }

        internal Atleta BuscarAtleta(string codigo)
        {
            return DAOAtleta.Instance.TrazerAtleta(codigo);
        }

        internal Treinador BuscarTreinador(string codigo)
        {
            return DAOTreinador.Instance.TrazerTreinador(codigo);
        }

        internal Exercicio BuscarExercicio(string codigo)
        {
            return DAOExercicio.Instance.BuscarExercicio(codigo);
        }

        internal Treino BuscarTreino(string codigo)
        {
            return DAOTreino.Instance.BuscarTreino(codigo);
        }

        internal void SalvarTreino()
        {
            DAOTreino.Instance.ValidarDadosTreino(CurrentTreino);
        }

        internal ObservableCollection<Treino> TrazerListaTreinos()
        {
            return DAOTreino.Instance.TrazerTreinos();
        }

        internal void ExcluirLancamento(Treino treino)
        {
            DAOTreino.Instance.ExcluirTreino(treino);
        }
    }
}
