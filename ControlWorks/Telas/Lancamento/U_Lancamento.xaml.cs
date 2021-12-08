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
    /// Interaction logic for U_Lancamento.xaml
    /// </summary>
    public partial class U_Lancamento : UserControl
    {
        private LancamentoController Controller;

        public U_Lancamento()
        {
            InitializeComponent();
            Controller = new LancamentoController();

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            W_ConsultaTreinador consTreinador = new W_ConsultaTreinador(new ConsultaTreinadorController());
            consTreinador.ShowDialog();

            if (consTreinador.CurrentTreinador != null)
            {
                Controller.CurrentTreino.Treinador = consTreinador.CurrentTreinador.DuplicarObjeto<Treinador>();
            }
        }

        private void TextBlock2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            W_ConsultaAtleta consAtleta = new W_ConsultaAtleta(new ConsultaAtletaController());
            consAtleta.ShowDialog();

            if (consAtleta.CurrentAtleta != null)
            {
                Controller.CurrentTreino.Atleta = consAtleta.CurrentAtleta.DuplicarObjeto<Atleta>();
            }
        }

        private void TextBlock_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.CurrentTreino.Atleta.Codigo))
                {
                    Atleta atleta = Controller.BuscarAtleta(Controller.CurrentTreino.Atleta.Codigo);

                    if (atleta != null)
                    {
                        Controller.CurrentTreino.Atleta = atleta.DuplicarObjeto<Atleta>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Atleta não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigoAtleta);
                    }
                }

                Controller.CurrentTreino.Atleta = new Atleta();
            }
        }



        private void TextBlock5_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.CurrentTreino.Codigo))
                {
                    Treino treino = Controller.BuscarTreino(Controller.CurrentTreino.Codigo);

                    if (treino != null)
                    {
                        Controller.CurrentTreino = treino.DuplicarObjeto<Treino>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Treino não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigo);
                    }
                }

                Controller.CurrentTreino = new Treino();
            }
        }

        private void TextBlock2_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.CurrentTreino.Treinador.Codigo))
                {
                    Treinador treinador = Controller.BuscarTreinador(Controller.CurrentTreino.Treinador.Codigo);

                    if (treinador != null)
                    {
                        Controller.CurrentTreino.Treinador = treinador.DuplicarObjeto<Treinador>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Treinador não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigoTreinador);
                    }
                }

                Controller.CurrentTreino.Treinador = new Treinador();
            }
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }

        private void rb01_Checked(object sender, RoutedEventArgs e)
        {
            Controller.TipoTreino = true;
            Controller.CurrentExercicio.TipoTreino = TrazerLista.Instance.ListaTipoTreino.FirstOrDefault(x => x.Codigo == "1");
            Controller.CurrentExercicio.Tempo = 0;
        }

        private void rb02_Checked(object sender, RoutedEventArgs e)
        {
            Controller.TipoTreino = false;
            Controller.CurrentExercicio.TipoTreino = TrazerLista.Instance.ListaTipoTreino.FirstOrDefault(x => x.Codigo == "2");
            Controller.CurrentExercicio.Tempo = 0;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColocarFocus(tbCodigo);
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDadosCurrentExercicio())
            {
                var exerc = Controller.CurrentExercicio.DuplicarObjeto<Exercicio>();

                Controller.CurrentTreino.L_Exercicio.Add(exerc);
                Controller.CurrentExercicio = new Exercicio();
                ColocarFocus(tbCodigoExercicio);
            }
        }

        private bool ValidarDadosCurrentExercicio()
        {
            if (string.IsNullOrEmpty(Controller.CurrentExercicio.Codigo))
            {
                MessageBox.Show("O código do Exercicio deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCodigoExercicio);
                return false;
            }

            if(Controller.CurrentExercicio.TipoTreino.Codigo == TipoTreino.TEMPO)
            {
                if(Controller.CurrentExercicio.Tempo <= 0)
                {
                    MessageBox.Show("O tempo do exercicio deve ser maior que 0", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                    ColocarFocus(tbTempoExercicio);
                    return false;
                }
            }

            return true;
        }

        private async void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ValidarCamposLancamentos())
                {
                    await Task.Run(() =>
                    {
                        Controller.SalvarTreino();
                    });

                    Controller.TelaDados = new U_LancamentoDados(Controller);
                    Controller.CurrentTreino = new Treino();
                    Controller.CurrentExercicio = new Exercicio();
                    ColocarFocus(tbCodigo);

                    MessageBox.Show("Os dados foram atualizados com sucesso!", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidarCamposLancamentos()
        {
            if (Controller.CurrentTreino.Data == null)
            {
                MessageBox.Show("A data deve ser preenchida corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbDataTreino);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreino.Titulo))
            {
                MessageBox.Show("O titulo do treino deve ser preenchida corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbTitulo);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreino.Treinador.Codigo))
            {
                MessageBox.Show("O treinador deve ser preenchida corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCodigoTreinador);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.CurrentTreino.Atleta.Codigo))
            {
                MessageBox.Show("O atleta deve ser preenchida corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCodigoAtleta);
                return false;
            }

            if (Controller.CurrentTreino.L_Exercicio?.Count() <= 0)
            {
                MessageBox.Show("Deve existir ao menos um exercicio para o treino", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCodigoExercicio);
                return false;
            }

            return true;
        }

        private void TextBlock3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            W_ConsultaExercicio consAtleta = new W_ConsultaExercicio(new ConsultaExercicioController());
            consAtleta.ShowDialog();

            if (consAtleta.CurrentExercicio != null)
            {
                Controller.CurrentExercicio = consAtleta.CurrentExercicio.DuplicarObjeto<Exercicio>();
            }
        }

        private void TextBlock3_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.CurrentExercicio.Codigo))
                {
                    Exercicio exercicio = Controller.BuscarExercicio(Controller.CurrentExercicio.Codigo);

                    if (exercicio != null)
                    {
                        Controller.CurrentExercicio = exercicio.DuplicarObjeto<Exercicio>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Exercicio não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigoExercicio);
                    }
                }

                Controller.CurrentExercicio = new Exercicio();
            }
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Util.percorrerCampos(e);
            }
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                if(dgExercicios.CurrentItem is Exercicio exerc)
                {
                    if(MessageBox.Show("Deseja remover o exercicio do treino?", "ControlWorks", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Controller.CurrentTreino.L_Exercicio.Remove(exerc);
                    }
                }
            }
        }
    }
}
