using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TravianTool.Janelas
{
    /// <summary>
    /// Interaction logic for LocalizarFarmsWindow.xaml
    /// </summary>
    public partial class LocalizarFarmsWindow : Window
    {
        private List<string> tribos = new List<string> {"Todos","Romano","Teutão","Gaulês", "Natarianos"};  

        public LocalizarFarmsWindow()
        {
            InitializeComponent();
        }

        private string NomeAldeia { get; set; }
        private int PopMin { get; set; }
        private int PopMax { get; set; }
        private int TriboSelecionada { get; set; }
        private int Distancia { get; set; }


        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var cb = sender as ComboBox;
            cb.ItemsSource = tribos;
            cb.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TriboSelecionada = (sender as ComboBox).SelectedIndex;
        }

        private void tbAldeia_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomeAldeia = (sender as TextBox).Text;
        }

        private void tbPopMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopMin = int.Parse((sender as TextBox).Text);
        }

        private void tbPopMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopMax = int.Parse((sender as TextBox).Text);
        }

        private void tbDist_TextChanged(object sender, TextChangedEventArgs e)
        {
            Distancia = int.Parse((sender as TextBox).Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Controle.ControleConsulta.statusMapa += Status;
        }

        private void Status(object sender, object e)
        {
            status.Text = e as string;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string consulta = NomeAldeia +'|'+ PopMin + '|' + PopMax + '|' + TriboSelecionada + '|' + Distancia;
            Controle.ControleConsulta.EfetuaConsulta(consulta);
        }
    }
}
