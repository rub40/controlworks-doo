using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    [Serializable]
    public class Exercicio : Notify
    {
        public Exercicio()
        {
            TipoTreino = new TipoTreino();
        }

        private TipoTreino tipoTreino;
        public TipoTreino TipoTreino
        {
            get => tipoTreino;
            set { tipoTreino = value; OnPropertyChanged(new PropertyChangedEventArgs("TipoTreino")); }
        }

        private int tempo;
        public int Tempo
        {
            get => tempo;
            set { tempo = value; OnPropertyChanged(new PropertyChangedEventArgs("Tempo")); }
        }

        private string codigo;
        public string Codigo
        {
            get => codigo;
            set { codigo = value; OnPropertyChanged(new PropertyChangedEventArgs("Codigo")); }
        }

        public long Cod
        {
            get
            {
                _ = long.TryParse(Codigo, out long cod64);
                return cod64;
            }
        }

        private string descricao;
        public string Descricao
        {
            get => descricao;
            set { descricao = value; OnPropertyChanged(new PropertyChangedEventArgs("Descricao")); }
        }


        public bool IsTempo
        {
            get
            {
                if(tipoTreino?.Codigo == TipoTreino.TEMPO)
                {
                    return true;
                }

                Tempo = 0;
                return false;
            }
        }
    }
}
