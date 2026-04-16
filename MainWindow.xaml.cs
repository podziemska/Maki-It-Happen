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
        SalaGlowna okno = new SalaGlowna();
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


            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();

            this.Close();
            okno.StartTutorial();
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // The Walking Dead
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserProfile okno2 = new UserProfile(okno);


            okno2.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno2.Show();


            this.Close();
        }

        private void Latwy_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 1;
            GameState.limit_czasu_sek = 60;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void Normalny_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 2;
            GameState.limit_czasu_sek = 30;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void Trudny_Click(object sender, RoutedEventArgs e)
        {
            GameState.poziom_trudnosci = 3;
            GameState.limit_czasu_sek = 15;
            PoziomPopup.IsOpen = false;
            UruchomGre();
        }

        private void StartGry()
        {
            MessageBox.Show("Start gry! Poziom: " + GameState.poziom_trudnosci);
        }
    }
}