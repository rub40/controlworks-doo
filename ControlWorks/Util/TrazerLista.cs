using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ControlWorks
{
    public class TrazerLista
    {
        private static TrazerLista instance;

        public static TrazerLista Instance
        {
            get
            {
                // DoubleLock
                if (instance == null)
                {
                    lock (m_lock)
                    {
                        if (instance == null)
                        {
                            instance = new TrazerLista();
                        }
                    }
                }
                return instance;
            }
        }

        //Helper for Thread Safety
        private static readonly object m_lock = new object();

        private ObservableCollection<TipoTreino> listaTipoTreino;
        public ObservableCollection<TipoTreino> ListaTipoTreino
        {
            get
            {
                if (listaTipoTreino == null)
                {
                    listaTipoTreino = new ObservableCollection<TipoTreino>
                    {
                        new TipoTreino(TipoTreino.TEMPO, "Tempo"),
                        new TipoTreino(TipoTreino.FISICO, "Fisico")
                    };
                }

                return listaTipoTreino;
            }
        }
    }
}
