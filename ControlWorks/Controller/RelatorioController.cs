using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks
{
    public class RelatorioController : Notify
    {
        public RelatorioController()
        {
            Atleta = new Atleta();
        }

        private DateTime? periodoInicial;
        public DateTime? PeriodoInicial
        {
            get => periodoInicial;
            set { periodoInicial = value; OnPropertyChanged(new PropertyChangedEventArgs("PeriodoInicial")); }
        }

        private DateTime? periodoFinal;
        public DateTime? PeriodoFinal
        {
            get => periodoFinal;
            set { periodoFinal = value; OnPropertyChanged(new PropertyChangedEventArgs("PeriodoFinal")); }
        }


        private Atleta atleta;
        public Atleta Atleta
        {
            get => atleta;
            set { atleta = value; OnPropertyChanged(new PropertyChangedEventArgs("Atleta")); }
        }

        internal Atleta BuscarAtleta(string codigo)
        {
            return DAOAtleta.Instance.TrazerAtleta(codigo);
        }
    }
}
