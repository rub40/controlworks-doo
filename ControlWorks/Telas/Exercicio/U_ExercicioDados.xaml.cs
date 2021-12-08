using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_TipoTreinoDados.xaml
    /// </summary>
    public partial class U_ExercicioDados : UserControl
    {
        public ExericicioController Controller;
        public U_ExercicioDados(ExericicioController controller)
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
            ObservableCollection<Exercicio> cpr = new ObservableCollection<Exercicio>();

            string ctxt = txt.ToUpper();

            if (ctxt.Length > 0)
            {
                for (int i = 0; i < Controller.L_Exercicio.Count(); i++)
                {
                    Exercicio l = Controller.L_Exercicio[i].DuplicarObjeto<Exercicio>();

                    string cprocura = l.Codigo.ToUpper() + l.Descricao.ToUpper() + l.Descricao.ToUpper() + l.TipoTreino?.Codigo?.ToUpper() + l.TipoTreino?.Descricao?.ToUpper();
                    int iprocura = cprocura.IndexOf(ctxt, 0);

                    if (iprocura >= 0)
                    {
                        cpr.Add(l);
                    }
                }

                dataGridExercicio.ItemsSource = cpr.OrderBy(p => p.Cod);
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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Exercicio> l_Exercicio = null;

            await Task.Run(() =>
            {
                l_Exercicio = Controller.TrazerListaTreinos();
            });

            Controller.L_Exercicio = new ObservableCollection<Exercicio>(l_Exercicio);
        }

        private void dataGridExercicio_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridExercicio.CurrentItem is Exercicio treino)
            {
                Controller.CurrentExercicio = treino.DuplicarObjeto<Exercicio>();
            }
        }
    }
}
