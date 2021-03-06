﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravianTool.Janelas;

namespace TravianTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LocalizarFarmsWindow windows = new LocalizarFarmsWindow();
            windows.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Controle.ControleConsulta.DownloadMapa();
            Controle.ControleConsulta.statusMapa += Status;
        }

        private void Status(object sender, object e)
        {
            status.Text = e as string;
        }
    }
}
