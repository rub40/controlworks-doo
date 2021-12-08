using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_Treinador.xaml
    /// </summary>
    public partial class U_Treinador : UserControl
    {
        private TreinadorController Controller;

        public U_Treinador()
        {
            InitializeComponent();

            Controller = new TreinadorController();

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidarTreinador())
                {
                    await Task.Run(() =>
                    {
                        Controller.SalvarTreinador();
                    });

                    Controller.TelaDados = new U_TreinadorDados(Controller);
                    Controller.CurrentTreinador = new Treinador();
                    ColocarFocus(tbCodigo);

                    MessageBox.Show("Os dados foram atualizados com sucesso!", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidarTreinador()
        {
            if (string.IsNullOrEmpty(Controller.CurrentTreinador.Cpf))
            {
                MessageBox.Show("O CPF deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCpf);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreinador.Endereco))
            {
                MessageBox.Show("O Endereco deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbEndereco);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreinador.Nome))
            {
                MessageBox.Show("O Nome deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbNome);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreinador.Telefone))
            {
                MessageBox.Show("O Telefone deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbTelefone);
                return false;
            }

            return true;
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Util.percorrerCampos(e);
            }
        }

        private void TextBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {

                if (!string.IsNullOrEmpty(Controller.CurrentTreinador.Codigo))
                {
                    Treinador treinador = Controller.L_Treinador.FirstOrDefault(x => x.Codigo == Controller.CurrentTreinador.Codigo);

                    if (treinador != null)
                    {
                        Controller.CurrentTreinador = treinador.DuplicarObjeto<Treinador>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Treinador não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigo);
                    }
                }

                Controller.CurrentTreinador = new Treinador();

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColocarFocus(tbCodigo);
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }
    }
}
