using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace ControlWorks
{
    public class DAOAtleta
    {
        private static DAOAtleta instance;

        public static DAOAtleta Instance
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
                            instance = new DAOAtleta();
                        }
                    }
                }
                return instance;
            }
        }

        //Helper for Thread Safety
        private static readonly object m_lock = new object();

        internal ObservableCollection<Atleta> TrazerAtletas()
        {
            ObservableCollection<Atleta> l_atleta = new ObservableCollection<Atleta>();

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, cpf, nome, endereco, telefone FROM atleta;";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Atleta dados = new Atleta();

                            dados.Codigo = dr["codigo"].ToString();
                            dados.Cpf = dr["cpf"].ToString();
                            dados.Nome = dr["nome"].ToString();
                            dados.Endereco = dr["endereco"].ToString();
                            dados.Telefone = dr["telefone"].ToString();


                            l_atleta.Add(dados);
                        }
                    }
                }
            }

            return new ObservableCollection<Atleta>(l_atleta.OrderBy(x => x.Cod));
        }

        internal Atleta TrazerAtleta(string codigo)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, cpf, nome, endereco, telefone FROM treinador WHERE codigo = " + codigo + "";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Atleta atleta = new Atleta();

                            atleta.Codigo = dr["codigo"].ToString();
                            atleta.Cpf = dr["cpf"].ToString();
                            atleta.Nome = dr["nome"].ToString();
                            atleta.Endereco = dr["endereco"].ToString();
                            atleta.Telefone = dr["telefone"].ToString();

                            return atleta;
                        }

                        return null;
                    }
                }
            }
        }

        internal void ValidaDadosAtleta(Atleta dados)
        {
            if (string.IsNullOrEmpty(dados.Codigo))
            {
                ADD_Atleta(dados);
            }
            else
            {
                UPD_Atleta(dados);
            }
        }

        private void ADD_Atleta(Atleta dados)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('" + dados.Cpf + "', '" + dados.Nome + "', '" + dados.Endereco + "', '" + dados.Telefone + "') RETURNING codigo;";
                    dados.Codigo = cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void UPD_Atleta(Atleta dados)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE atleta SET cpf = '" + dados.Cpf + "', nome = '" + dados.Nome + "', endereco = '" + dados.Endereco + "', telefone = '" + dados.Telefone + "' WHERE codigo = " + dados.Codigo + ";";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool ConsultarAtleta(Atleta dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EXISTS(SELECT 1 FROM atleta WHERE codigo = " + dados.Codigo + ");";
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }
    }
}
