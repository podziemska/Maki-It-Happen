using System.Windows;

namespace Maki_it_happen
{
    public partial class GameWindow : Window
    {
        int IloscRyzu = 10;
        int IloscRyby = 5;
        int IloscOgorka = 8;
        int IloscNori = 12;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void AddRice_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ryż";
            
            
            if (IloscRyzu >= 1)
            {
                IloscRyzu--;
                RiceCountLabel.Text = $"Szt: {IloscRyzu}";
            }
            else {
                RiceCountLabel.Text = "Ryż się skończył! Idz do sklepu!";
            }

            // TODO: Dodaj grafikę ryżu na talerz 
        }

        private void AddFish_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ryba";
          
            if (IloscRyby >= 1)
            {
                IloscRyby--;
                FishCountLabel.Text = $"Szt: {IloscRyby}";
            }
            else
            {
                FishCountLabel.Text = "Łosoś się skończył! Idz do sklepu!";
            }
            // TODO: Dodaj grafikę ryby na talerz
        }

        private void AddCucumber_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "ogórek";
          
            if (IloscOgorka >= 1)
            {
                IloscOgorka--;
                CucumberCountLabel.Text = $"Szt: {IloscOgorka}";
            }
            else
            {
                CucumberCountLabel.Text = "Ogórek się skończył! Idz do sklepu!";
            }
            // TODO: Dodaj grafikę ogórka na talerz
        }

        private void AddNori_Click(object sender, RoutedEventArgs e)
        {
            usun.Content = "nori";
            if (IloscNori >= 1)
            {
                IloscNori--;
                NoriCountLabel.Text = $"Szt: {IloscNori}";
            }
            else
            {
                NoriCountLabel.Text = "Nori się skończyło! Idz do sklepu!";
            }
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
