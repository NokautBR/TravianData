using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TravianData
{
    class LoadMapSql
    {

        public void GetSqlFile()
        {
            WebClient client = new WebClient();
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

        public void PopulaBanco()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|DatabaseTravian.mdf;Integrated Security=True;User Instance=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            foreach (var linha in LoadSqlFile())
            {
                //Remove the back tick from the name of the table, because this only
                //works with MySQL, in SQL Server this throws an error
                //line = line.Replace("`", "");

                cmd.CommandText = linha;
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }
    }
}
