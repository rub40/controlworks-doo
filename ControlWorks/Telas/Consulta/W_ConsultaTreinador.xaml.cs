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
    /// Interaction logic for W_ConsultaTreinadorAtleta.xaml
    /// </summary>
    public partial class W_ConsultaTreinador : Window
    {
        private ConsultaTreinadorController Controller;
        public Treinador CurrentTreinador;

        public W_ConsultaTreinador(ConsultaTreinadorController controller)
        {
            InitializeComponent();
            Controller = controller;

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Treinador> l_treinador = null;

            await Task.Run(() =>
            {
                l_treinador = Controller.TrazerListaTreinador();
            });

            Controller.L_Treinador = new ObservableCollection<Treinador>(l_treinador);
        }

        private void dataGridTreinador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridTreinador.CurrentItem is Treinador treinador)
            {
                CurrentTreinador = treinador;
            }

            Close();
        }

        private void Pesquisar(string txt)
        {
            ObservableCollection<Treinador> cpr = new ObservableCollection<Treinador>();

            string ctxt = txt.ToUpper();

            if (ctxt.Length > 0)
            {
                if (Controller.L_Treinador != null)
                {
                    for (int i = 0; i < Controller.L_Treinador.Count; i++)
                    {
                        Treinador l = Controller.L_Treinador[i];

                        string cprocura = l.Codigo.ToUpper() + l.Cpf.Trim().ToUpper() + l.Nome.ToUpper() + l.Telefone.ToUpper() + l.Endereco.ToUpper();
                        int iprocura = cprocura.IndexOf(ctxt, 0);

                        if (iprocura >= 0)
                        {
                            cpr.Add(l);
                        }
                    }

                    dataGridTreinador.ItemsSource = cpr.OrderBy(p => p.Cod);
                }
            }
            else
            {
                dataGridTreinador.ItemsSource = Controller.L_Treinador.OrderBy(p => p.Cod);
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

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
