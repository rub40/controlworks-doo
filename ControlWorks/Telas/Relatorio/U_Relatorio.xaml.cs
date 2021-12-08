using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for U_Relatorio.xaml
    /// </summary>
    public partial class U_Relatorio : UserControl
    {
        public RelatorioController Controller;
        public U_Relatorio()
        {
            InitializeComponent();
            Controller = new RelatorioController();

            SetarDataContext();
        }

        private void SetarDataContext()
        {
            DataContext = Controller;
        }

        private async void BtnGerarRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposRelatorio())
            {
                string caminhoArquivo = BuscarCaminhoArquivo();

                if (string.IsNullOrEmpty(caminhoArquivo))
                {
                    ColocarFocus(tbDataInicial);
                    return;
                }

                ObservableCollection<Treino> l_treinos = null;
                Dictionary<string, Exercicio> dicExerciciosTempo = null;
                Dictionary<string, Exercicio> dicExerciciosFisico = null;
                Dictionary<string, Exercicio> dicMes = null;
                Dictionary<string, Treinador> dicTreinadores = null;

                await Task.Run(() =>
                {
                    l_treinos = DAOTreino.Instance.BuscarTreinosRelatorio(Controller.PeriodoInicial.Value, Controller.PeriodoFinal.Value, Controller.Atleta.Codigo);

                    
                    dicExerciciosTempo = GerarDicionarioExercicios(l_treinos, TipoTreino.TEMPO);
                    dicExerciciosFisico = GerarDicionarioExercicios(l_treinos, TipoTreino.FISICO);
                    dicMes = GerarDicionarioExerciciosPorMes(l_treinos);
                    dicTreinadores = GerarDicionarioTreinadores(l_treinos);

                });

                var arquivo = Gerar(caminhoArquivo, dicExerciciosTempo, dicTreinadores, dicMes, dicExerciciosFisico);
                SalvarArquivo(caminhoArquivo, arquivo);
                MessageBox.Show("Arquivo de relatório salvo com sucesso!", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void SalvarArquivo(string caminhoArquivo, StringBuilder SB)
        {
            if (File.Exists(caminhoArquivo))
            {
                File.Create(caminhoArquivo).Close();
            }

            StreamWriter arquivoSped = File.CreateText(caminhoArquivo);
            arquivoSped.Close();

            using (StreamWriter writer = new StreamWriter(caminhoArquivo, true, Encoding.Default, 65536))
            {
                writer.Write(SB.ToString());
                writer.Flush();
            }
        }

        private string BuscarCaminhoArquivo()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".txt";
            saveDialog.Filter = "Texto (.txt)|*.txt";
            saveDialog.FileName = "RELATORIO_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + Util.RemoverAcentos(Controller.Atleta.Nome).Replace(" ", "_") + "_CONTROLWORKS";

            string caminhoArquivo = string.Empty;

            if (saveDialog.ShowDialog() == true)
            {
                caminhoArquivo = saveDialog.FileName;
            }

            return caminhoArquivo;
        }

        private StringBuilder Gerar(string caminhoArquivo, Dictionary<string, Exercicio> dicExerciciosTempo, Dictionary<string, Treinador> dicTreinadores, Dictionary<string, Exercicio> dicMes, Dictionary<string, Exercicio> dicExerciciosFisico)
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("PERIODO: " + Controller.PeriodoInicial.Value.ToString("dd/MM/yyyy") + " ATÉ " + Controller.PeriodoFinal.Value.ToString("dd/MM/yyyy"));
            SB.AppendLine("ATLETA: " + Controller.Atleta.Nome.ToUpper() + "");
            
            if (dicExerciciosTempo.Count > 0)
            {
                SB.AppendLine("___________________________________________________");
                SB.AppendLine("TOTAL DE TEMPO GASTOS POR EXERCICIO:");
                SB.AppendLine("___________________________________________________");

                foreach (var exerc in dicExerciciosTempo)
                {
                    SB.AppendLine(exerc.Value.Descricao + ": " + exerc.Value.Tempo + " segundos");
                }

                SB.AppendLine("");
                SB.AppendLine("");
            }

            if(dicMes.Count > 0)
            {
                SB.AppendLine("___________________________________________________");
                SB.AppendLine("TOTAL DE TEMPO GASTOS POR MÊS EXERCICIO:");
                SB.AppendLine("___________________________________________________");

                string controlePeriodo = string.Empty;
                foreach (var exerc in dicMes)
                {
                    string periodo = exerc.Key.Split("|")[0];

                    if (periodo != controlePeriodo)
                    {
                        SB.AppendLine(periodo);
                        controlePeriodo = periodo;
                    }

                    SB.AppendLine(exerc.Value.Descricao + ": " + exerc.Value.Tempo + " segundos");
                }

                SB.AppendLine("");
                SB.AppendLine("");
            }

            if(dicExerciciosFisico.Count > 0)
            {
                SB.AppendLine("___________________________________________________");
                SB.AppendLine("TREINOS FISICOS:");
                SB.AppendLine("___________________________________________________");

                foreach (var exerc in dicExerciciosFisico)
                {
                    SB.AppendLine(exerc.Value.Descricao);
                }

                SB.AppendLine("");
                SB.AppendLine("");
            }

            if(dicTreinadores.Count > 0)
            {
                SB.AppendLine("___________________________________________________");
                SB.AppendLine("TREINADORES ENVOLVIDOS:");
                SB.AppendLine("___________________________________________________");

                foreach (var treinador in dicTreinadores)
                {
                    SB.AppendLine(treinador.Value.Nome);
                }

                SB.AppendLine("");
                SB.AppendLine("");
            }

            return SB;
        }

        private Dictionary<string, Treinador> GerarDicionarioTreinadores(ObservableCollection<Treino> l_treinos)
        {

            Dictionary<string, Treinador> dicTreinador = new Dictionary<string, Treinador>();

            foreach (var treino in l_treinos)
            {
                if (!dicTreinador.TryGetValue(treino.Treinador.Codigo, out Treinador dados))
                {
                    dicTreinador.Add(treino.Treinador.Codigo, treino.Treinador.DuplicarObjeto<Treinador>());
                }
            }

            return dicTreinador;
        }

        private Dictionary<string, Exercicio> GerarDicionarioExerciciosPorMes(ObservableCollection<Treino> l_treinos)
        {
            Dictionary<string, Exercicio> dicMes = new Dictionary<string, Exercicio>();

            foreach (var treino in l_treinos)
            {
                ObservableCollection<Exercicio> l_Exercicio = new ObservableCollection<Exercicio>(treino.L_Exercicio.Where(x => x.TipoTreino.Codigo == TipoTreino.TEMPO).ToList());

                foreach(var exerc in l_Exercicio)
                {

                    if (!dicMes.TryGetValue(treino.Data.Value.Month + "/" + treino.Data.Value.Year + "|" + exerc.Codigo, out Exercicio dados))
                    {
                        dicMes.Add(treino.Data.Value.Month + "/" + treino.Data.Value.Year + "|" + exerc.Codigo, exerc);
                    }
                    else
                    {
                        dados.Tempo += exerc.Tempo;
                    }
                }
            }

            return dicMes;
        }

        private Dictionary<string, Exercicio> GerarDicionarioExercicios(ObservableCollection<Treino> l_treinos, string tipoTreino)
        {
            Dictionary<string, Exercicio> dicExercicio = new Dictionary<string, Exercicio>();

            if(tipoTreino == TipoTreino.TEMPO)
            {
                foreach (var treino in l_treinos)
                {
                    ObservableCollection<Exercicio> l_treino = new ObservableCollection<Exercicio>(treino.L_Exercicio.Where(x => x.TipoTreino.Codigo == TipoTreino.TEMPO).ToList());

                    foreach (var exerc in l_treino)
                    {
                        if (dicExercicio.TryGetValue(exerc.Codigo, out Exercicio dados))
                        {
                            dados.Tempo += exerc.Tempo;
                        }
                        else
                        {
                            dicExercicio.Add(exerc.Codigo, exerc.DuplicarObjeto<Exercicio>());
                        }
                    }
                }
            }
            else
            {
                foreach (var treino in l_treinos)
                {
                    ObservableCollection<Exercicio> l_treino = new ObservableCollection<Exercicio>(treino.L_Exercicio.Where(x => x.TipoTreino.Codigo == TipoTreino.FISICO).ToList());

                    foreach (var exerc in l_treino)
                    {
                        if (!dicExercicio.TryGetValue(exerc.Codigo, out Exercicio dados))
                        {
                            dicExercicio.Add(exerc.Codigo, exerc.DuplicarObjeto<Exercicio>());
                        }
                    }
                }
            }
           

            return dicExercicio;
        }

        private bool ValidarCamposRelatorio()
        {
            if (Controller.PeriodoInicial == null)
            {
                MessageBox.Show("O período inícial deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbDataInicial);
                return false;
            }

            if (Controller.PeriodoFinal == null)
            {
                MessageBox.Show("O período final deve ser preenchido corretamente", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbDataFinal);
                return false;
            }

            if (Controller.PeriodoFinal < Controller.PeriodoInicial)
            {
                MessageBox.Show("O período inícial não deve ser maior que o período final", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbDataInicial);
                return false;
            }

            if (string.IsNullOrEmpty(Controller.Atleta.Codigo))
            {
                MessageBox.Show("É necessário preencher o código do atleta", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                ColocarFocus(tbCodigoAtleta);
                return false;
            }

            return true;
        }

        private void ColocarFocus(IInputElement focus)
        {
            _ = Dispatcher.BeginInvoke((Action)delegate
            {
                _ = Keyboard.Focus(focus);
            }, DispatcherPriority.ContextIdle);
        }

        private void TextBlock2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            W_ConsultaAtleta consAtleta = new W_ConsultaAtleta(new ConsultaAtletaController());
            consAtleta.ShowDialog();

            if (consAtleta.CurrentAtleta != null)
            {
                Controller.Atleta = consAtleta.CurrentAtleta.DuplicarObjeto<Atleta>();
            }
        }

        private void TextBlock_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.OldValue == true) && ((bool)e.NewValue == false))
            {
                if (!string.IsNullOrEmpty(Controller.Atleta.Codigo))
                {
                    Atleta atleta = Controller.BuscarAtleta(Controller.Atleta.Codigo);

                    if (atleta != null)
                    {
                        Controller.Atleta = atleta.DuplicarObjeto<Atleta>();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Atleta não cadastrado", "ControlWorks", MessageBoxButton.OK, MessageBoxImage.Information);
                        ColocarFocus(tbCodigoAtleta);
                    }
                }

                Controller.Atleta = new Atleta();
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
