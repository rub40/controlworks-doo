using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControlWorks
{
    public class Usuario : Notify
    {
        public Usuario()
        {

        }

        public Usuario(string login, string password)
        {
            Login = login;
            Password = password;
        }

        private string login;
        public string Login
        {
            get => login;
            set { login = value; OnPropertyChanged(new PropertyChangedEventArgs("Login")); }
        }

        private string password;
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(new PropertyChangedEventArgs("Password")); }
        }
    }
}
