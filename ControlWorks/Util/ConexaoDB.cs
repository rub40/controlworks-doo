using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ControlWorks
{

    static class ConexaoDB
    {
        private static string serverName = "127.0.0.1";
        private static string port = "5433";
        public static string userName = "controlwork";
        private static string password = "1234";
        public static string databaseName = "controlworksdb";

        private static IDbConnection conDB = null;
        public static IDbConnection ConexaoAvulsa(bool Open = false)
        {
            string CONN = "";
            NpgsqlConnection conAvulsa;

            if (conDB != null)
            {
                CONN = conDB.ConnectionString;
            }
            else
            {
                conDB = new NpgsqlConnection(string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", serverName, port, userName, password, databaseName));
                CONN = conDB.ConnectionString;
            }

            conAvulsa = new NpgsqlConnection(CONN);


            if (Open)
            {
                try
                {
                    conAvulsa.Open();
                }
                catch (Exception ex)
                {
                    switch (ex.Message.ToString())
                    {
                        case "Host can't be null":
                        case "Este host não é conhecido":
                            throw new Exception("Falha na conexão:\nIP do servidor não encontrado/em branco.");
                        default:
                            throw ex;
                    }
                }
            }

            return conAvulsa;
        }


        public static void CriarBancoDados()
        {
            InitilializeDB initDB = new InitilializeDB();
            initDB.Inicializar();
        }
    }
}
