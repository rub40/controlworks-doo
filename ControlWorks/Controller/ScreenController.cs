using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ControlWorks
{
    public class ScreenController : Notify
    {
        public static ObservableCollection<Screen> L_Screen = new ObservableCollection<Screen>();

        #region Tags
        public const string TELA_LANCAMENTO = "TELA_LANCAMENTO";
        public const string CADASTRO_ATLETA = "CADASTRO_ATLETA";
        public const string CADASTRO_TREINADOR = "CADASTRO_TREINADOR";
        public const string GERAR_RELATORIOS = "GERAR_RELATORIOS";
        public const string CADASTRO_EXERCICIO = "CADASTRO_EXERCICIO";
        #endregion

        public static Screen GetScreen(string tag)
        {
            UserControl user = GetTagString(tag);
            return GenerateScreen(tag, user);
        }

        private static UserControl GetTagString(string tag)
        {
            UserControl user = null;

            switch (tag)
            {
                case TELA_LANCAMENTO:
                    return new U_Lancamento();
                case CADASTRO_ATLETA:
                    return new U_Atleta();
                case CADASTRO_TREINADOR:
                    return new U_Treinador();
                case GERAR_RELATORIOS:
                    return new U_Relatorio();
                case CADASTRO_EXERCICIO:
                    return new U_Exercicio();
            }

            return user;
        }

        private static Screen GenerateScreen(string tag, UserControl UserControl)
        {
            Screen userScreen = L_Screen.FirstOrDefault(x => x.Tag.Equals(tag));

            LimparFocus();
            LimparMemoria();

            if (userScreen == null)
            {
                string title = BuscarTitle(tag);
                userScreen = new Screen(tag, title, UserControl);
                L_Screen.Add(userScreen);
            }

            return userScreen;
        }

        private static string BuscarTitle(string tag)
        {
            switch (tag)
            {
                case TELA_LANCAMENTO:
                    return "Tela de lançamentos";
                case CADASTRO_ATLETA:
                    return "Cadastro de atletas";
                case CADASTRO_TREINADOR:
                    return "Cadastro de treinadores";
                case GERAR_RELATORIOS:
                    return "Tela de relatórios";
                case CADASTRO_EXERCICIO:
                    return "Cadastro de exercicios";
                default:
                    return "";
            }
        }

        public static void LimparFocus()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Keyboard.ClearFocus();
            }, DispatcherPriority.Send);
        }

        public async static void LimparMemoria()
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });
        }
    }
}
