using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    [Serializable]
    public class Atleta : Notify
    {
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

        private string nome;
        public string Nome
        {
            get => nome;
            set { nome = value; OnPropertyChanged(new PropertyChangedEventArgs("Nome")); }
        }

        private string cpf;
        public string Cpf
        {
            get => cpf;
            set { cpf = value; OnPropertyChanged(new PropertyChangedEventArgs("Cpf")); }
        }

        private string endereco;
        public string Endereco
        {
            get => endereco;
            set { endereco = value; OnPropertyChanged(new PropertyChangedEventArgs("Endereco")); }
        }

        private string telefone;
        public string Telefone
        {
            get => telefone;
            set { telefone = value; OnPropertyChanged(new PropertyChangedEventArgs("Telefone")); }
        }
    }
}
