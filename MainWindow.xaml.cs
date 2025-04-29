using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string sciezkaDoZdjecia = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WybierzZdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.jpg;*.png)|*.jpg;*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                sciezkaDoZdjecia = dialog.FileName;
                SciezkaZdjecia.Text = sciezkaDoZdjecia;
                PodgladZdjecia.Source = new BitmapImage(new Uri(sciezkaDoZdjecia));
            }
        }

        private void ZapiszWpis_Click(object sender, RoutedEventArgs e)
        {
            string tekstWpisu = PoleTekstowe.Text;

            if (string.IsNullOrWhiteSpace(tekstWpisu))
            {
                MessageBox.Show("Wpis jest pusty!");
                return;
            }

            string wpis = $"Data: {DateTime.Now}\nTekst:\n{tekstWpisu}\nZdjęcie: {sciezkaDoZdjecia}\n---\n";

            string sciezkaPliku = "pamietnik.txt";
            File.AppendAllText(sciezkaPliku, wpis);

            MessageBox.Show("Wpis został zapisany!");
            PoleTekstowe.Clear();
            PodgladZdjecia.Source = null;
            SciezkaZdjecia.Text = "";
        }
    }
}
