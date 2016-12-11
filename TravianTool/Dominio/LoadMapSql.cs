using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Controls;
using TravianTool.Controle;

namespace TravianData
{
    class LoadMapSql
    {

        public void GetSqlFile()
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += ControleConsulta.Client_DownloadFileCompleted;
            client.DownloadProgressChanged += ControleConsulta.Client_DownloadProgressChanged;
            Directory.CreateDirectory("Dados");
            FileInfo fi = new FileInfo(@"Dados\Map.sql");
            TimeSpan dias = DateTime.Now.Date - fi.CreationTime.Date.AddDays(1);
            if (dias.Days >= 1)
                client.DownloadFileAsync(new Uri("http://ts2.travian.com.br/map.sql"), @"Dados\Map.sql");

        }

        private string[] LoadSqlFile()
        {
            if (File.Exists(@"Dados\Map.sql"))
            {
                string[] sql = File.ReadAllLines(@"Dados\Map.sql");
                return sql;
            }
            return null;
        }

        public void PopulaBanco(ProgressBar progresso)
        {
            string conexao = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string[] querys = LoadSqlFile();
            for (var linha = 0; linha < querys.Length; linha++)
            {
                //Remove the back tick from the name of the table, because this only
                //works with MySQL, in SQL Server this throws an error
                querys[linha] = querys[linha].Replace("`", "");
                
                cmd.CommandText = querys[linha];
                cmd.ExecuteNonQuery();
                progresso.Value = (linha * 100 / querys.Length);
            }

            con.Close();
        }


    }
}
