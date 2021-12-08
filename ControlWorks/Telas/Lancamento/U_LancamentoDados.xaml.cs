using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_LancamentoDados.xaml
    /// </summary>
    public partial class U_LancamentoDados : UserControl
    {
        private LancamentoController Controller;
        public U_LancamentoDados(LancamentoController controller)
        {
            InitializeComponent();
            Controller = controller;

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private void Pesquisar(string txt)
        {
            ObservableCollection<Treino> cpr = new ObservableCollection<Treino>();

            string ctxt = txt.ToUpper();

            if (ctxt.Length > 0)
            {
                for (int i = 0; i < Controller.L_Treino.Count(); i++)
                {
                    Treino l = Controller.L_Treino[i].DuplicarObjeto<Treino>();

                    string cprocura = l.Codigo.ToUpper() + l.Codigo.ToUpper() + l.Titulo.ToUpper() + l.Data?.ToString("dd/MM/yyyy");
                    int iprocura = cprocura.IndexOf(ctxt, 0);

                    if (iprocura >= 0)
                    {
                        cpr.Add(l);
                    }
                }

                dataGridLancamentos.ItemsSource = cpr.OrderBy(p => p.Cod);
            }
            else
            {
                dataGridLancamentos.ItemsSource = Controller.L_Treino.OrderBy(p => p.Cod);
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

        private void dataGridLancamentos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dataGridLancamentos.CurrentItem is Treino treino)
            {
                Controller.CurrentTreino = treino.DuplicarObjeto<Treino>();
            }
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ObservableCollection<Treino> l_Treino = null;

            await Task.Run(() =>
            {
                l_Treino = Controller.TrazerListaTreinos();
            });

            Controller.L_Treino = new ObservableCollection<Treino>(l_Treino);
        }

        private void dataGridLancamentos_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                if (MessageBox.Show("Deseja realmente excluir o lançamento selecionado?", "ControlWorks", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (dataGridLancamentos.CurrentItem is Treino treino)
                    {
                        Controller.ExcluirLancamento(treino);
                    }
                }
            }
        }
    }
}
