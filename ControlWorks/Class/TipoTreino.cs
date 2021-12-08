using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    [Serializable]
    public class TipoTreino : Notify
    {
        public const string TEMPO = "1";
        public const string FISICO = "2";

        public TipoTreino()
        {

        }

        public TipoTreino(string codigo, string desc)
        {
            Codigo = codigo;
            Descricao = desc;
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

        private string descricao;
        public string Descricao
        {
            get => descricao;
            set { descricao = value; OnPropertyChanged(new PropertyChangedEventArgs("Descricao")); }
        }

        public string CompletoAutomatico
        {
            get
            {
                if (!string.IsNullOrEmpty(Codigo) && !string.IsNullOrEmpty(Descricao))
                {
                    return Codigo + " - " + Descricao.ToUpper();
                }

                return null;
            }
            set { }
        }
    }
}
