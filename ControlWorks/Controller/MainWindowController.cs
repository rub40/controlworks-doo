using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks.Controller
{
    public class MainWindowController : Notify
    {
        public MainWindowController(Usuario user)
        {
            Usuario = user;

            ScreenController = new ScreenController();
            CurrentScreen = ScreenController.GetScreen(ScreenController.TELA_LANCAMENTO);
        }

        private Usuario usuario;
        public Usuario Usuario
        {
            get => usuario;
            set { usuario = value; OnPropertyChanged(new PropertyChangedEventArgs("Usuario")); }
        }

        private Screen currentScreen;
        public Screen CurrentScreen
        {
            get => currentScreen;
            set { currentScreen = value; OnPropertyChanged(new PropertyChangedEventArgs("CurrentScreen")); }
        }

        private ScreenController screenController;
        public ScreenController ScreenController
        {
            get => screenController;
            set { screenController = value; OnPropertyChanged(new PropertyChangedEventArgs("ScreenController")); }
        }
    }
}
