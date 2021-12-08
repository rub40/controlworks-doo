using ControlWorks.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for W_Login.xaml
    /// </summary>
    public partial class W_Login : Window
    {
        private LoginController Controller;
        public W_Login()
        {
            InitializeComponent();
            Controller = new LoginController();

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Controller.Usuario = new Usuario(tbLogin.Text, tbPassword.Password);

            if (string.IsNullOrEmpty(Controller.Usuario.Login))
            {
                ColocarFocus(tbLogin);
                return;
            }

            if (string.IsNullOrEmpty(Controller.Usuario.Password))
            {
                ColocarFocus(tbPassword);
                return;
            }

            if (!Controller.ValidaUsuario())
            {
                MessageBox.Show("Os dados do usuário estão incorretos", "Control Work's", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparCampos();
                ColocarFocus(tbLogin);
                return;
            }

            EntrarSistema();
        }

        private void LimparCampos()
        {
            Controller.Usuario = new Usuario();

            tbLogin.Text = string.Empty;
            tbPassword.Password = string.Empty;
        }

        private void EntrarSistema()
        {
            W_MainWindow sistema = new W_MainWindow(new MainWindowController(Controller.Usuario));

            Close();
            sistema.Show();
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Util.percorrerCampos(e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColocarFocus(tbLogin);
        }
    }
}
