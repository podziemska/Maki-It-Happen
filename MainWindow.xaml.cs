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
            SalaGlowna okno = new SalaGlowna();
           
            // Ustawienie okna na środku ekranu przed jego pokazaniem
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();

            // Zamykamy obecne okno (np. Menu Główne)
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
    }
}
