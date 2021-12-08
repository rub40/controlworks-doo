using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace ControlWorks
{
    public class DAOTreinador
    {
        private static DAOTreinador instance;

        public static DAOTreinador Instance
        {
            get
            {
                // DoubleLock
                if (instance == null)
                {
                    lock (m_lock)
                    {
                        if (instance == null)
                        {
                            instance = new DAOTreinador();
                        }
                    }
                }
                return instance;
            }
        }

        //Helper for Thread Safety
        private static readonly object m_lock = new object();

        internal ObservableCollection<Treinador> TrazerTreinadores()
        {
            ObservableCollection<Treinador> l_treinador = new ObservableCollection<Treinador>();

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, cpf, nome, endereco, telefone FROM treinador;";

                    using(IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Treinador dados = new Treinador();

                            dados.Codigo = dr["codigo"].ToString();
                            dados.Cpf = dr["cpf"].ToString();
                            dados.Nome = dr["nome"].ToString();
                            dados.Endereco = dr["endereco"].ToString();
                            dados.Telefone = dr["telefone"].ToString();


                            l_treinador.Add(dados);
                        }
                    }
                }
            }

            return new ObservableCollection<Treinador>(l_treinador.OrderBy(x => x.Cod));
        }

        internal Treinador TrazerTreinador(string codigo)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, cpf, nome, endereco, telefone FROM treinador WHERE codigo = " + codigo + "";

                    using(IDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Treinador treinador = new Treinador();

                            treinador.Codigo = dr["codigo"].ToString();
                            treinador.Cpf = dr["cpf"].ToString();
                            treinador.Nome = dr["nome"].ToString();
                            treinador.Endereco = dr["endereco"].ToString();
                            treinador.Telefone = dr["telefone"].ToString();

                            return treinador;
                        }

                        return null;
                    }
                }
            }
        }

        internal void ValidarDadosTreinador(Treinador dados)
        {
            if (string.IsNullOrEmpty(dados.Codigo))
            {
                ADD_Treinador(dados);
            }
            else
            {
                UPD_Treinador(dados);
            }
        }

        private void ADD_Treinador(Treinador dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('" + dados.Cpf + "', '" + dados.Nome + "', '" + dados.Endereco + "', '" + dados.Telefone + "') RETURNING codigo;";
                    dados.Codigo = cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void UPD_Treinador(Treinador dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE treinador SET cpf = '" + dados.Cpf + "', nome = '" + dados.Nome + "', endereco = '" + dados.Endereco + "', telefone = '" + dados.Telefone + "' WHERE codigo = " + dados.Codigo + ";";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool ConsultarTreinador(Treinador dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EXISTS(SELECT 1 FROM treinador WHERE codigo = " + dados.Codigo + ");";
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }
    }
}
