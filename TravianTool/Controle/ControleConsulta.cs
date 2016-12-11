using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravianData;
using TravianTool.Dominio;

namespace TravianTool.Controle
{
    static class ControleConsulta
    {
        static public EventHandler<object> statusMapa;

        static public void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                statusMapa?.Invoke(sender, "Download Completo");

                ProgressBar progresso = new ProgressBar();
                progresso.ValueChanged += Progresso_ValueChanged;
                LoadMapSql map = new LoadMapSql();
                map.PopulaBanco(progresso);
            }
            else
            {
                statusMapa?.Invoke(sender, "Erro ao baixar arquivo do servidor do Travian");
            }
        }

        private static void Progresso_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue < 99)
            {
                statusMapa?.Invoke(sender, "Criando Banco de Dados... " + e.NewValue + "%"); 
            }
            else
            {
                statusMapa?.Invoke(sender, "Banco de Dados criado");
            }
        }

        static public void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            statusMapa?.Invoke(sender, "Baixando Mapa: " + e.ProgressPercentage + "%");
        }

        static public void DownloadMapa()
        {
            LoadMapSql map = new LoadMapSql();
            map.GetSqlFile();
        }

        static public void EfetuaConsulta(string consulta)
        {
            string[] filtros = consulta.Split('|');
            ConsultaBD consultaBD = new ConsultaBD();
            if (!string.IsNullOrEmpty(filtros[0])) consultaBD.AddNomeAldeia(filtros[0]);
            if (!filtros[1].Equals("0")) consultaBD.AddPopMin(int.Parse(filtros[1]));
            if (!filtros[1].Equals("0")) consultaBD.AddPopMax(int.Parse(filtros[2]));
            if (!filtros[1].Equals("0")) consultaBD.AddTribo(int.Parse(filtros[3]));
            if (!filtros[1].Equals("0")) consultaBD.AddDistancia(int.Parse(filtros[4]));

            consultaBD.EfetuaConsulta();
        }
    }
}
