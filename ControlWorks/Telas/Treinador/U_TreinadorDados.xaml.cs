using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_AtletaDados.xaml
    /// </summary>
    public partial class U_TreinadorDados : UserControl
    {
        private TreinadorController Controller;
        public U_TreinadorDados(TreinadorController controller)
        {
            InitializeComponent();
            Controller = controller;

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                Controller.CurrentTreinador = treinador.DuplicarObjeto<Treinador>();
            }
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

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Util.percorrerCampos(e);
            }
        }
    }
}
