using ControlWorks.Controller;
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

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class W_MainWindow : Window
    {
        private MainWindowController Controller = null;

        public W_MainWindow(MainWindowController controller)
        {
            InitializeComponent();
            Controller = controller;

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;

            var tela = ScreenController.GetScreen(menu.Tag.ToString());

            if (tela != null)
            {
                Controller.CurrentScreen = tela;
            }
        }
    }
}
