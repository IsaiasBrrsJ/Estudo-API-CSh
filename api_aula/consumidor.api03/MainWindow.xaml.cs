using System.Windows;
using Flurl.Http;
using Flurl;
using System.Collections;
using consumidor.api03.Model;
using System.Collections.Generic;

namespace consumidor.api03
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

        private async void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7131/";
            var ednpoint = url+"api/TarefaItems";

            IEnumerable<Trabalho> listaTarefa =  ednpoint.GetJsonAsync<IEnumerable<Trabalho>>().Result;

            dtgGrid.ItemsSource = listaTarefa;
        }
    }
}
