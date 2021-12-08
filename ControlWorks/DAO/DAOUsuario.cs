using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ControlWorks
{
    public class DAOUsuario
    {
        public bool GetLogin(Usuario user)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EXISTS(SELECT 1 FROM usuario WHERE login = '" + user.Login + "' AND senha = '" + user.Password + "')";
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }
    }
}
