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

namespace Maki_it_happen
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
        private void Graj_Click(object sender, RoutedEventArgs e)
        {
            PoziomPopup.IsOpen = true;
        }
        private void UruchomGre()
        {
            SalaGlowna okno = new SalaGlowna();

            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();

            this.Close();
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // The Walking Dead
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserProfile okno = new UserProfile();


            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();

            
            this.Close();
        }

        private void Latwy_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 1;
            GameState.limit_czasu_sek = 100;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void Normalny_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 2;
            GameState.limit_czasu_sek = 50;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void Trudny_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 3;
            GameState.limit_czasu_sek = 30;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void StartGry()
        {
            MessageBox.Show("Start gry! Poziom: " + GameState.poziom_trudnosci);
        }
    }
}
