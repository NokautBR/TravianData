using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.IO;

namespace TravianData
{ 

    public partial class Form1 : System.Windows.Forms.Form
    {
        List<string> listaSalva, listaNatares, listaLinks = new List<string>();
        IEnumerable<string> listaPendente;

        public Form1()
        {
            InitializeComponent();
        }
        private List<string> ExtraiInfoHtml(HtmlDocument htmlSnippet)
        {
            List<string> aldeiasNatares = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                if(link.InnerText.Contains("Natares"))
                    aldeiasNatares.Add(link.InnerText);
            }

            return aldeiasNatares;
        }

        private HtmlDocument CarregaArquivoHtml(string file)
        {
            TextReader reader = File.OpenText(file);
            HtmlDocument doc = new HtmlDocument();
            doc.Load(reader);
            reader.Close();
            return doc;
        }

        private void lvLinks_ItemActivate(object sender, EventArgs e)
        {
            if (listaLinks.Count > 0)
            {
                string link = lvLinks.SelectedItems[0].Text;
                lvLinks.SelectedItems[0].Remove();
                System.Diagnostics.Process.Start(link);
            }
        }

        private void btnGerarLinks_Click(object sender, EventArgs e)
        {
            foreach(var aldeia in listaPendente)
            {
                string[] temp = aldeia.Split(' ');
                string[] xy = temp[1].Split('|');
                int x = Int32.Parse(xy[0]);
                int y = Int32.Parse(xy[1]);
                string endereco = string.Format("http://ts2.travian.com.br/position_details.php?x={0}&y={1}", x, y);
                listaLinks.Add(endereco);

                lvLinks.Items.Clear();
                foreach (var item in listaLinks)
                {
                    lvLinks.Items.Add(item);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HtmlDocument aldeiasSalvas, aldeiasNatares = new HtmlDocument();

            aldeiasSalvas = CarregaArquivoHtml(@"D:\Teste\Arquivos\Travian.txt");
            aldeiasNatares = CarregaArquivoHtml(@"D:\Teste\Arquivos\Natarianos.txt");

            listaSalva = ExtraiInfoHtml(aldeiasSalvas);
            listaNatares = ExtraiInfoHtml(aldeiasNatares);

            listaPendente = listaNatares.Except(listaSalva);

            foreach (var item in listaPendente)
            {
                lvLinks.Items.Add(item);
            }

            lbNatarianos.Text = "" + listaNatares.Count + " Natarianos";
            lbSalvos.Text = "" + listaSalva.Count + " Cadastrados";
            lbPendentes.Text = "" + lvLinks.Items.Count + " Pendentes";
        }
    }
}
