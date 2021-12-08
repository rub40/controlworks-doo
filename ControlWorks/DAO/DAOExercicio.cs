using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace ControlWorks
{
    public class DAOExercicio
    {
        private static DAOExercicio instance;

        public static DAOExercicio Instance
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
                            instance = new DAOExercicio();
                        }
                    }
                }
                return instance;
            }
        }

        //Helper for Thread Safety
        private static readonly object m_lock = new object();

        internal ObservableCollection<Exercicio> TrazerExercicios()
        {
            ObservableCollection<Exercicio> l_Exercicios = new ObservableCollection<Exercicio>();

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, descricao, tipo FROM exercicio;";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Exercicio dados = new Exercicio();

                            dados.Codigo = dr["codigo"].ToString();
                            dados.TipoTreino = TrazerLista.Instance.ListaTipoTreino.FirstOrDefault(x => x.Codigo == dr["tipo"].ToString());
                            dados.Descricao = dr["descricao"].ToString();


                            l_Exercicios.Add(dados);
                        }
                    }
                }
            }

            return new ObservableCollection<Exercicio>(l_Exercicios.OrderBy(x => x.Cod));
        }

        internal Exercicio BuscarExercicio(string codigo)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo, descricao, tipo FROM exercicio WHERE codigo = " + codigo + "";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Exercicio exercicio = new Exercicio();

                            exercicio.Codigo = dr["codigo"].ToString();
                            exercicio.Descricao = dr["descricao"].ToString();
                            exercicio.TipoTreino = TrazerLista.Instance.ListaTipoTreino.FirstOrDefault(x => x.Codigo == dr["tipo"].ToString()); 

                            return exercicio;
                        }

                        return null;
                    }
                }
            }
        }

        internal ObservableCollection<Exercicio> BuscarListaExercicioTreino(string codigo)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT exercicio.codigo, exercicio.descricao, exercicio.tipo, rela.tempo FROM rela_treino_exercicio rela LEFT JOIN exercicio ON exercicio.codigo = rela.codigo WHERE rela.codigo_treino = " + codigo + "";

                    ObservableCollection<Exercicio> l_exercicio = new ObservableCollection<Exercicio>();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Exercicio exercicio = new Exercicio();

                            exercicio.Codigo = dr["codigo"].ToString();
                            exercicio.Descricao = dr["descricao"].ToString();
                            exercicio.TipoTreino = TrazerLista.Instance.ListaTipoTreino.FirstOrDefault(x => x.Codigo == dr["tipo"].ToString());
                            
                            if (!string.IsNullOrEmpty(dr["tempo"].ToString()))
                            {
                                exercicio.Tempo = int.Parse(dr["tempo"].ToString());
                            }


                            l_exercicio.Add(exercicio);
                        }

                        return l_exercicio;
                    }
                }
            }
        }

        internal void ValidarDadosExercicio(Exercicio dados)
        {
            if (string.IsNullOrEmpty(dados.Codigo))
            {
                ADD_Exercicio(dados);
            }
            else
            {
                UPD_Exercicio(dados);
            }
        }

        private bool ConsultarExercicio(Exercicio dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EXISTS(SELECT 1 FROM exercicio WHERE codigo = " + dados.Codigo + ");";
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }

        private void UPD_Exercicio(Exercicio dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE exercicio SET descricao = '" + dados.Descricao + "', tipo = '" + dados.TipoTreino.Codigo + "' WHERE codigo = " + dados.Codigo + ";";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ADD_Exercicio(Exercicio dados)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO exercicio (descricao, tipo) VALUES ('" + dados.Descricao + "', '" + dados.TipoTreino.Codigo + "') RETURNING codigo;";
                    dados.Codigo = cmd.ExecuteScalar().ToString();
                }
            }
        }
    }
}
