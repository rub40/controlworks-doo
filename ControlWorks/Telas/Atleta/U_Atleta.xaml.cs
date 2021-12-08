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
    /// Interaction logic for U_Atleta.xaml
    /// </summary>
    public partial class U_Atleta : UserControl
    {
        private AtletaController Controller;
        public U_Atleta()
        {
            InitializeComponent();
            Controller = new AtletaController();

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
                if (ValidarAtleta())
                {
                    await Task.Run(() =>
                    {
                        Controller.SalvarAtleta();
                    });

                    Controller.TelaDados = new U_AtletaDados(Controller);
                    
                    MessageBox.Show("Os dados foram atualizados com sucesso!", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidarAtleta()
        {
            if (string.IsNullOrEmpty(Controller.CurrentAtleta.Cpf))
            {
                MessageBox.Show("O CPF deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCpf);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentAtleta.Endereco))
            {
                MessageBox.Show("O Endereco deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbEndereco);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentAtleta.Nome))
            {
                MessageBox.Show("O Nome deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbNome);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentAtleta.Telefone))
            {
                MessageBox.Show("O Telefone deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbTelefone);
                return false;
            }

            return true;
        }

        private void TextBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.CurrentAtleta.Codigo))
                {
                    Atleta atleta = Controller.L_Atleta.FirstOrDefault(x => x.Codigo == Controller.CurrentAtleta.Codigo);

                    if (atleta != null)
                    {
                        Controller.CurrentAtleta = atleta.DuplicarObjeto<Atleta>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Atleta não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigo);
                    }
                }

                Controller.CurrentAtleta = new Atleta();

            }
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Util.percorrerCampos(e);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColocarFocus(tbCodigo);
        }
    }
}
