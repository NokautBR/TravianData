using System;
using System.Collections.Generic;
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
            client.DownloadFileAsync(new Uri("http://ts2.travian.com.br/map.sql"), @"D:\Teste\Arquivos\Map.sql");
        }

        public void LoadSqlFile()
        {
            string[] sql = File.ReadAllLines(@"D:\Teste\Arquivos\Map.sql");
        }
    }
}
