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
        }
        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserProfile okno = new UserProfile();


            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();


            this.Close();
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

            KlientImage.Visibility = Visibility.Visible;
            Panel.SetZIndex(KlientImage, 10);

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
                MessageBox.Show("Klient zadowolony!");
                GameState.Kasa += 10;
            }
            else
            {
                MessageBox.Show("Klient niezadowolony!");
            }

            KlientImage.Visibility = Visibility.Hidden;
            czyKlientCzeka = false;
            OdbierzBtn.IsEnabled = false;
            ZamowienieLabel.Text = "";

            AktualizujKase();
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
                case "Onigiri": obraz = "onigiriGotowe2.png"; break; //tylko to dziala
                case "Nigiri": obraz = "nigiri.png"; break; //w domu
                case "Hosomaki": obraz = "hosomakiGotowe2.png"; break; // w domu
                case "Futomaki": obraz = "futomakiGotowe2.png"; break; // w domu 
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
