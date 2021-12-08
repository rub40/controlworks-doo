using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ControlWorks
{
    public class InitilializeDB
    {
        private IDbConnection conDBPrimaria = null;

        public InitilializeDB()
        {
            conDBPrimaria = new NpgsqlConnection(string.Format("Server={0};Port={1};User Id={2};Password={3};", "localhost", "5433", "postgres", "1234"));
            conDBPrimaria.Open();
        }

        public bool VerificarExistenciaBD()
        {
            using (IDbCommand cmd = conDBPrimaria.CreateCommand())
            {
                cmd.CommandText = "SELECT DATNAME FROM pg_catalog.pg_database WHERE DATNAME = '" + ConexaoDB.databaseName.ToLower() + "';";
                var ret = cmd.ExecuteScalar();

                if (ret == null)
                {
                    return false;
                }

                return true;
            }
        }

        internal void Inicializar()
        {
            if (!VerificarExistenciaBD())
            {
                CriarBancoDados();
            }
            else
            {
                ResetarSequences();
            }

            conDBPrimaria.Close();

            CriarTabelas();
            PopularBancoDados();
        }

        private void ResetarSequences()
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "ALTER SEQUENCE treinador_codigo_seq RESTART WITH 1;";
                    cmd.CommandText += "ALTER SEQUENCE atleta_codigo_seq RESTART WITH 1;";
                    cmd.CommandText += "ALTER SEQUENCE exercicio_codigo_seq RESTART WITH 1;";
                    cmd.CommandText += "ALTER SEQUENCE treino_codigo_seq RESTART WITH 1;";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CriarTabelas()
        {
            using (var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using (IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS atleta (" +
                         "codigo SERIAL PRIMARY KEY," +
                         "cpf CHARACTER VARYING(11)," +
                         "nome CHARACTER VARYING," +
                         "endereco CHARACTER VARYING," +
                         "telefone CHARACTER VARYING(14))";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS treinador (" +
                       "codigo SERIAL PRIMARY KEY," +
                       "cpf CHARACTER VARYING(11)," +
                       "nome CHARACTER VARYING," +
                       "endereco CHARACTER VARYING," +
                       "telefone CHARACTER VARYING(14))";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS exercicio (" +
                        "codigo SERIAL PRIMARY KEY," +
                        "descricao CHARACTER VARYING," +
                        "tipo CHARACTER VARYING)";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS usuario (" +
                        "login CHARACTER VARYING(8)," +
                        "senha CHARACTER VARYING(20))";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS treino (" +
                        "codigo SERIAL," +
                        "data DATE," +
                        "titulo CHARACTER VARYING," +
                        "codigo_treinador INTEGER," +
                        "codigo_atleta INTEGER)";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS rela_treino_exercicio (" +
                        "codigo INTEGER," +
                        "codigo_treino INTEGER)";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void CriarBancoDados()
        {
            using (IDbCommand cmd = conDBPrimaria.CreateCommand())
            {
                cmd.CommandText = "CREATE DATABASE " + ConexaoDB.databaseName + " WITH OWNER " + ConexaoDB.userName + " ENCODING = 'UTF8' CONNECTION LIMIT = -1;";
                cmd.ExecuteNonQuery();

            }
        }

        private void PopularBancoDados()
        {
            using(var NpgsqlConn = ConexaoDB.ConexaoAvulsa(true))
            {
                using(IDbCommand cmd = NpgsqlConn.CreateCommand())
                {
                    string sql = MontarDeletes();
                    sql += MontarInserts();

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string MontarInserts()
        {
            string sql = "";

            sql += "INSERT INTO usuario (login, senha) VALUES ('teste', '1234');";

            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('Nado Craw', '2');";
            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('Nado Borboleta', '2');";
            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('Nado Costas', '2');";
            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('500 Metros Rasos', '1');";
            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('1000 Metros Rasos', '1');";
            sql += "INSERT INTO exercicio (descricao, tipo) VALUES ('100 Metros Rasos', '1');";

            sql += "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('12345678910', 'Betão', 'Rua Joaquim Algusto dos Santos, 194', '(16)3129-1233');";
            sql += "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('12321314214', 'Lucas Rodrigues', 'Rua Algustos, 194', '(16)3129-1133');";
            sql += "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('28143562431', 'Amanda Caires', 'Rua Aquidaban, 1487', '(16)1231-3123');";
            sql += "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('61265431245', 'Arthur Vinicius', 'Rua Leopoldina, 1823', '(16)3123-3255');";
            sql += "INSERT INTO atleta (cpf, nome, endereco, telefone) VALUES ('21432156341', 'José Rubens', 'Rua Armando Bezerra, 12312', '(16)3123-3123');";
            

            sql += "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('12345678910', 'Matheus Rodrigues', 'Rua Pipipi, 194', '(16)3125-1233');";
            sql += "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('12321314214', 'Allan Mello', 'Rua Mello, 194', '(16)3119-1133');";
            sql += "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('28143562431', 'David Pian', 'Rua Pianzinho, 1487', '(16)1231-3123');";
            sql += "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('61265431245', 'Dulce Pian', 'Rua Leopoldina, 155', '(16)2133-3255');";
            sql += "INSERT INTO treinador (cpf, nome, endereco, telefone) VALUES ('21432156341', 'José Roberto', 'Rua Bezerra, 11112', '(16)3111-1123');";


            return sql;
        }

        private string MontarDeletes()
        {
            return "DELETE FROM usuario;DELETE FROM exercicio;DELETE FROM atleta;DELETE FROM treinador;";
        }
    }
}
