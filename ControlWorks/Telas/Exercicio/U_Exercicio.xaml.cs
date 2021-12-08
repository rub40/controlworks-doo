using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ControlWorks
{
    /// <summary>
    /// Interaction logic for U_TipoTreino.xaml
    /// </summary>
    public partial class U_Exercicio : UserControl
    {
        private ExericicioController Controller;
        public U_Exercicio()
        {
            InitializeComponent();
            Controller = new ExericicioController();
            DataContext = Controller;
        }

        private void TextBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {

                if (!string.IsNullOrEmpty(Controller.CurrentExercicio.Codigo))
                {
                    Exercicio exercicio = Controller.L_Exercicio.FirstOrDefault(x => x.Codigo == Controller.CurrentExercicio.Codigo);

                    if (exercicio != null)
                    {
                        Controller.CurrentExercicio = exercicio.DuplicarObjeto<Exercicio>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Exercicio não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigo);
                    }
                }

                Controller.CurrentExercicio = new Exercicio();

            }
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }

        private async void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidarTreino())
                {
                    await Task.Run(() =>
                    {
                       Controller.SalvarTreino();
                    });

                    Controller.TelaDados = new U_ExercicioDados(Controller);

                    MessageBox.Show("Os dados foram atualizados com sucesso!", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidarTreino()
        {
            if (string.IsNullOrEmpty(Controller.CurrentExercicio.TipoTreino.Descricao))
            {
                MessageBox.Show("O Tipo deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCpf);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentExercicio.Descricao))
            {
                MessageBox.Show("A descrição deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCpf);
                return false;
            }

            return true;
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
