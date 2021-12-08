using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class LoginController : Notify
    {
        private DAOUsuario DAOUsuario = null;

        public LoginController()
        {
            Usuario = new Usuario();
            DAOUsuario = new DAOUsuario();
        }

        private Usuario usuario;
        public Usuario Usuario
        {
            get => usuario;
            set { usuario = value; OnPropertyChanged(new PropertyChangedEventArgs("Usuario")); }
        }

        internal bool ValidaUsuario()
        {
            return DAOUsuario.GetLogin(Usuario);
        }
    }
}
