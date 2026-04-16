using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Maki_it_happen
{
    public partial class SalaGlowna : Window
    {
        public bool czyKlientCzeka = false;
        Random rand = new Random();

        public SalaGlowna()
        {
            InitializeComponent();
            AktualizujKase();
            PokazSushi();
            KlientImage.Source = new BitmapImage(new Uri("/images/klientBlanka.png", UriKind.Relative));


        }
        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserProfile okno = new UserProfile(this);
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide();
        }
        public void AktualizujKase()
        {
            KasaLabel.Text = $"Kasa: {GameState.Kasa}$";
        }

        private void GenerujZamowienie()
        {
            string[] menu = { "Onigiri", "Nigiri", "Hosomaki", "Futomaki" };
            GameState.CurrentOrder = menu[rand.Next(menu.Length)];
            ZamowienieLabel.Text = $"Zamówienie: {GameState.CurrentOrder}";
        }

        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            if (czyKlientCzeka)
            {
                MessageBox.Show("Przy ladzie już stoi klient!");
                return;
            }

            KlientImage.Source = new BitmapImage(new Uri("/images/klientBlanka.png", UriKind.Relative));

            czyKlientCzeka = true;
            OdbierzBtn.IsEnabled = true;

            GenerujZamowienie();
        }

        public void OdbierzZamowienie_Click(object sender, RoutedEventArgs e)
        {
            if (!czyKlientCzeka) return;

            bool good = (GameState.LastSushi == GameState.CurrentOrder);

            if (good)
            {
                KlientImage.Source = new BitmapImage(new Uri("/images/zadowolony.png", UriKind.Relative));
                GameState.Kasa += 10;
                MessageBox.Show("Klient zadowolony!");
                GameState.LiczbaKlientow++;
            }
            else
            {
                KlientImage.Source = new BitmapImage(new Uri("/images/niezadowolony.png", UriKind.Relative));
                MessageBox.Show("To nie jest to, co zamawiałem!");
                GameState.LiczbaKlientow++;
            }

            GameState.LastSushi = ""; 
            GameState.CurrentOrder = ""; 
                                         

            czyKlientCzeka = false;
            OdbierzBtn.IsEnabled = false;
            ZamowienieLabel.Text = "";
            SushiImage.Source = null;
            AktualizujKase();
            MessageBox.Show("Liczba klientów: " + GameState.LiczbaKlientow);
        }


        private void Kuchnia_Click(object sender, RoutedEventArgs e)
        {
            if (!czyKlientCzeka)
            {
                MessageBox.Show("Najpierw przyjmij zamówienie od klienta!");
                return;
            }

            GameWindow okno = new GameWindow(this);
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide();

        }
        public void PokazSushi()
        {
            string obraz = "";

            switch (GameState.LastSushi)
            {
                case "Onigiri": obraz = "onigiriGotowe2.png"; break; 
                case "Nigiri": obraz = "nigiriGotowe2.png"; break; 
                case "Hosomaki": obraz = "hosomakiGotowe2.png"; break; 
                case "Futomaki": obraz = "futomakiGotowe2.png"; break; 
            }

            if (!string.IsNullOrEmpty(obraz))
            {
                SushiImage.Source = new BitmapImage(
                    new Uri($"/images/{obraz}", UriKind.Relative)
                );
            }
        }
    }
}
