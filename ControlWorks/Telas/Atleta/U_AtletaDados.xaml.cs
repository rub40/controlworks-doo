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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_AtletaDados.xaml
    /// </summary>
    public partial class U_AtletaDados : UserControl
    {
        private AtletaController Controller;
        public U_AtletaDados(AtletaController controller)
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
            ObservableCollection<Atleta> l_atleta = null;

            await Task.Run(() =>
            {
                l_atleta = Controller.TrazerListaAtleta();
            });

            Controller.L_Atleta = new ObservableCollection<Atleta>(l_atleta);
        }

        private void dataGridAtleta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridAtleta.CurrentItem is Atleta atleta)
            {
                Controller.CurrentAtleta = atleta.DuplicarObjeto<Atleta>();
            }
        }

        private void Pesquisar(string txt)
        {
            ObservableCollection<Atleta> cpr = new ObservableCollection<Atleta>();

            string ctxt = txt.ToUpper();

            if (ctxt.Length > 0)
            {
                if (Controller.L_Atleta != null)
                {
                    for (int i = 0; i < Controller.L_Atleta.Count; i++)
                    {
                        Atleta l = Controller.L_Atleta[i];

                        string cprocura = l.Codigo.ToUpper() + l.Cpf.Trim().ToUpper() + l.Nome.ToUpper() + l.Telefone.ToUpper() + l.Endereco.ToUpper();
                        int iprocura = cprocura.IndexOf(ctxt, 0);

                        if (iprocura >= 0)
                        {
                            cpr.Add(l);
                        }
                    }

                    dataGridAtleta.ItemsSource = cpr.OrderBy(p => p.Cod);
                }
            }
            else
            {
                dataGridAtleta.ItemsSource = Controller.L_Atleta.OrderBy(p => p.Cod);
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
    }
}
