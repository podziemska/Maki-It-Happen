using System.Windows;

namespace Maki_it_happen
{
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void AddRice_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ryż";
            // TODO: Zmniejsz licznik ryżu o 1
            // TODO: Dodaj grafikę ryżu na talerz 
        }

        private void AddFish_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ryba";
            // TODO: Zmniejsz licznik ryby o 1
            // TODO: Dodaj grafikę ryby na talerz
        }

        private void AddCucumber_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ogórek";
            // TODO: Zmniejsz licznik ogórka o 1
            // TODO: Dodaj grafikę ogórka na talerz
        }

        private void AddNori_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "nori";
            // TODO: Zmniejsz licznik nori o 1
            // TODO: Dodaj grafikę nori na talerz
        }

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "serwuj";
            // TODO: Sprawdź czy składniki na talerzu pasują do zamówienia
            // TODO: Jeśli tak -> dodaj kasę i wyczyść talerz
        }

        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy i otwieramy nowe okno sklepu
            ShopWindow oknoSklepu = new ShopWindow();
            oknoSklepu.ShowDialog(); // ShowDialog blokuje kuchnię, póki nie zamkniesz sklepu
        }
    }
}
