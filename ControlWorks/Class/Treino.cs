using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    [Serializable]
    public class Treino : Notify
    {
        public Treino()
        {
            Treinador = new Treinador();
            Atleta = new Atleta();
            L_Exercicio = new ObservableCollection<Exercicio>();
        }

        private Treinador treinador;
        public Treinador Treinador
        {
            get => treinador;
            set { treinador = value; OnPropertyChanged(new PropertyChangedEventArgs("Treinador")); }
        }

        public long Cod
        {
            get
            {
                _ = long.TryParse(Codigo, out long cod64);
                return cod64;
            }
        }

        private string codigo;
        public string Codigo
        {
            get => codigo;
            set { codigo = value; OnPropertyChanged(new PropertyChangedEventArgs("Codigo")); }
        }

        private string titulo;
        public string Titulo
        {
            get => titulo;
            set { titulo = value; OnPropertyChanged(new PropertyChangedEventArgs("Titulo")); }
        }

        private DateTime? data;
        public DateTime? Data
        {
            get => data;
            set { data = value; OnPropertyChanged(new PropertyChangedEventArgs("Data")); }
        }

        private Atleta atleta;
        public Atleta Atleta
        {
            get => atleta;
            set { atleta = value; OnPropertyChanged(new PropertyChangedEventArgs("Atleta")); }
        }

        private ObservableCollection<Exercicio> l_Exercicio;
        public ObservableCollection<Exercicio> L_Exercicio
        {
            get => l_Exercicio;
            set { l_Exercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("L_Exercicio")); }
        }

        private int quantidadeExercicio;
        public int QuantidadeExercicio
        {
            get => quantidadeExercicio;
            set { quantidadeExercicio = value; OnPropertyChanged(new PropertyChangedEventArgs("QuantidadeExercicio")); }
        }
    }
}
