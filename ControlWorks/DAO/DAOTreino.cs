using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks
{
    public class DAOTreino : Notify
    {
        private static DAOTreino instance;

        public static DAOTreino Instance
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
                            instance = new DAOTreino();
                        }
                    }
                }
                return instance;
            }
        }

        //Helper for Thread Safety
        private static readonly object m_lock = new object();

        internal Treino BuscarTreino(string codigo)
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT treino.codigo, treino.data, treino.titulo, treinador.codigo as codigotreinador, treinador.nome as nometreinador, atleta.nome as nomeatleta, atleta.codigo as codigoatleta FROM treino LEFT JOIN treinador ON treinador.codigo = treino.codigo_treinador LEFT JOIN atleta ON atleta.codigo = treino.codigo_atleta WHERE treino.codigo = '" + codigo + "';";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Treino dados = new Treino
                            {
                                Atleta = new Atleta(),
                                Treinador = new Treinador()
                            };

                            dados.Codigo = dr["codigo"].ToString();

                            if (!string.IsNullOrEmpty(dr["data"].ToString()))
                            {
                                dados.Data = Convert.ToDateTime(dr["data"].ToString());
                            }

                            dados.Treinador.Codigo = dr["codigotreinador"].ToString();
                            dados.Treinador.Nome = dr["nometreinador"].ToString();
                            dados.Atleta.Codigo = dr["codigoatleta"].ToString();
                            dados.Atleta.Nome = dr["nomeatleta"].ToString();
                            dados.Titulo = dr["titulo"].ToString();

                            dados.L_Exercicio = DAOExercicio.Instance.BuscarListaExercicioTreino(dados.Codigo);

                            return dados;
                        }

                        return null;
                    }
                }
            }
        }

        internal void ExcluirTreino(Treino treino)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "DELETE from treino where codigo = '" + treino.Codigo + "';";
                    cmd.CommandText += "DELETE from rela_treino_exercicio where codigo_treino = '" + treino.Codigo + "';";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal ObservableCollection<Treino> TrazerTreinos()
        {
            ObservableCollection<Treino> l_treino = new ObservableCollection<Treino>();

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT treino.codigo, treino.data, treino.titulo, treinador.codigo as codigotreinador, treinador.nome as nometreinador, atleta.nome as nomeatleta, atleta.codigo as codigoatleta FROM treino LEFT JOIN treinador ON treinador.codigo = treino.codigo_treinador LEFT JOIN atleta ON atleta.codigo = treino.codigo_atleta;";

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Treino dados = new Treino
                            {
                                Atleta = new Atleta(),
                                Treinador = new Treinador()
                            };

                            dados.Codigo = dr["codigo"].ToString();

                            if (!string.IsNullOrEmpty(dr["data"].ToString()))
                            {
                                dados.Data = Convert.ToDateTime(dr["data"].ToString());
                            }

                            dados.Titulo = dr["titulo"].ToString();
                            dados.Treinador.Codigo = dr["codigotreinador"].ToString();
                            dados.Treinador.Nome = dr["nometreinador"].ToString();
                            dados.Atleta.Codigo = dr["codigoatleta"].ToString();
                            dados.Atleta.Nome = dr["nomeatleta"].ToString();

                            dados.L_Exercicio = DAOExercicio.Instance.BuscarListaExercicioTreino(dados.Codigo);

                            l_treino.Add(dados);
                        }
                    }
                }
            }

            return new ObservableCollection<Treino>(l_treino.OrderBy(x => x.Cod));
        }

        internal void ValidarDadosTreino(Treino dados)
        {
            if (string.IsNullOrEmpty(dados.Codigo))
            {
                ADD_Treino(dados);
            }
            else
            {
                UPD_Treino(dados);
            }
        }

        private void DELETE_ExercicioTreino(Treino dados)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM rela_treino_exercicio WHERE codigo_treino = '" + dados.Codigo + "';";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal ObservableCollection<Treino> BuscarTreinosRelatorio(DateTime periodoInicial, DateTime periodoFinal, string codigoAtleta)
        {
            ObservableCollection<Treino> l_treino = new ObservableCollection<Treino>();

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT treino.codigo, treino.data, treino.titulo, treinador.codigo as codigotreinador, treinador.nome as nometreinador, atleta.nome as nomeatleta, atleta.codigo as codigoatleta FROM treino LEFT JOIN treinador ON treinador.codigo = treino.codigo_treinador LEFT JOIN atleta ON atleta.codigo = treino.codigo_atleta WHERE treino.codigo_atleta = '" + codigoAtleta + "' AND data BETWEEN '" + periodoInicial.ToString("dd/MM/yyyy") + "' AND '" + periodoFinal.ToString("dd/MM/yyyy") + "';";
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Treino dados = new Treino
                            {
                                Atleta = new Atleta(),
                                Treinador = new Treinador()
                            };

                            dados.Codigo = dr["codigo"].ToString();

                            if (!string.IsNullOrEmpty(dr["data"].ToString()))
                            {
                                dados.Data = Convert.ToDateTime(dr["data"].ToString());
                            }

                            dados.Titulo = dr["titulo"].ToString();
                            dados.Treinador.Codigo = dr["codigotreinador"].ToString();
                            dados.Treinador.Nome = dr["nometreinador"].ToString();
                            dados.Atleta.Codigo = dr["codigoatleta"].ToString();
                            dados.Atleta.Nome = dr["nomeatleta"].ToString();

                            dados.L_Exercicio = DAOExercicio.Instance.BuscarListaExercicioTreino(dados.Codigo);

                            l_treino.Add(dados);
                        }
                    }
                }
            }

            return new ObservableCollection<Treino>(l_treino.OrderBy(x => x.Cod));

        }

        private void ADD_Treino(Treino dados)
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO treino (data, titulo, codigo_treinador, codigo_atleta) VALUES ('" + dados.Data.Value.ToString("dd/MM/yyyy") + "', '" + dados.Titulo + "', '" + dados.Treinador.Codigo + "', '" + dados.Atleta.Codigo + "') RETURNING codigo;";
                    dados.Codigo = cmd.ExecuteScalar().ToString();
                }
            }

            SalvarExerciciosTreino(dados);
        }

        private void UPD_Treino(Treino dados)
        {

            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE treino SET data='" + dados.Data.Value.ToString("dd/MM/yyyy") + "', titulo='" + dados.Titulo + "', codigo_treinador='" + dados.Treinador.Codigo + "', codigo_atleta='" + dados.Atleta.Codigo + "';";
                    cmd.ExecuteNonQuery();
                }
            }

            SalvarExerciciosTreino(dados);
        }

        private void SalvarExerciciosTreino(Treino dados)
        {
            DELETE_ExercicioTreino(dados);

            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    string sql = "";

                    foreach(var item in dados.L_Exercicio)
                    {
                        sql += "INSERT INTO rela_treino_exercicio (codigo, codigo_treino, tempo) VALUES ('" + item.Codigo + "', '" + dados.Codigo + "', '" + item.Tempo + "');";
                    }

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
