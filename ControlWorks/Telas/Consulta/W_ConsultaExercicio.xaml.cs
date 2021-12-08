using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for W_ConsultaTipoTreinamento.xaml
    /// </summary>
    public partial class W_ConsultaExercicio : Window
    {
        private ConsultaExercicioController Controller;
        public Exercicio CurrentExercicio;

        public W_ConsultaExercicio(ConsultaExercicioController controller)
        {
            InitializeComponent();
            Controller = controller;

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void dataGridExercicio_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridExercicio.CurrentItem is Exercicio exercicio)
            {
                CurrentExercicio = exercicio;
            }

            Close();
        }

        private void Pesquisar(string txt)
        {
            ObservableCollection<Exercicio> cpr = new ObservableCollection<Exercicio>();

            string ctxt = txt.ToUpper();

            if (ctxt.Length > 0)
            {
                if (Controller.L_Exercicio != null)
                {
                    for (int i = 0; i < Controller.L_Exercicio.Count; i++)
                    {
                        Exercicio l = Controller.L_Exercicio[i];

                        string cprocura = l.Codigo.ToUpper() + l.Descricao.ToUpper() + l.TipoTreino.Codigo.ToUpper() + l.TipoTreino?.Codigo?.ToUpper() + l.TipoTreino?.Descricao?.ToUpper();
                        int iprocura = cprocura.IndexOf(ctxt, 0);

                        if (iprocura >= 0)
                        {
                            cpr.Add(l);
                        }
                    }

                    dataGridExercicio.ItemsSource = cpr.OrderBy(p => p.Cod);
                }
            }
            else
            {
                dataGridExercicio.ItemsSource = Controller.L_Exercicio.OrderBy(p => p.Cod);
            }
        }

        private void tbPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox otext = sender as TextBox;
            if (otext.Name == "tbPesquisar")
            {
                Pesquisar(otext.Text);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Exercicio> l_Exercicio = null;

            await Task.Run(() =>
            {
                l_Exercicio = Controller.TrazerListaExercicio();
            });

            Controller.L_Exercicio = new ObservableCollection<Exercicio>(l_Exercicio);
        }
    }
}
