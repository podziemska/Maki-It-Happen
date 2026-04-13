using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Maki_it_happen
{
    public partial class SalaGlowna : Window
    {
        // Flaga sprawdzająca, czy klient aktualnie czeka
        public bool czyKlientCzeka = false;
        private string aktualneZamowienie = "";

        Random rand = new Random();

        public SalaGlowna()
        {
            InitializeComponent();
            AktualizujKase();
            PokazSushi();
        }

        public void AktualizujKase()
        {
            KasaLabel.Text = $"Kasa: {GameState.Kasa}$$";
        }
        private void GenerujZamowienie()
        {
            string[] menu = { "Onigiri", "Nigiri", "Hosomaki", "Futomaki" };

            aktualneZamowienie = menu[rand.Next(menu.Length)];

            ZamowienieLabel.Text = $"Zamówienie: {aktualneZamowienie}";
            GameState.CurrentOrder = aktualneZamowienie;

        }
        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            if (czyKlientCzeka)
            {
                MessageBox.Show("Przy ladzie już stoi klient!");
                return;
            }

            KlientImage.Visibility = Visibility.Visible;
            KlientImage.Opacity = 1;

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
                MessageBox.Show("ZADOWOLONY beda obrazki");
                GameState.Kasa += 10;
            }
            else
            {
                MessageBox.Show("NIEZADOWOLONY beda obrazki");
            }

            KlientImage.Visibility = Visibility.Hidden;

            czyKlientCzeka = false;
            OdbierzBtn.IsEnabled = false;
            ZamowienieLabel.Text = "";

            AktualizujKase();
        }
        private void Kuchnia_Click(object sender, RoutedEventArgs e)
        {
            GameWindow okno = new GameWindow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide();
        }
        private void PokazSushi()
        {
            string obraz = "";

            switch (GameState.LastSushi)
            {
                case "Onigiri": obraz = "onitest.png"; break; //tego jeszcze n ma
                case "Nigiri": obraz = "nigiri.png"; break; //tego jeszcze n ma
                case "Hosomaki": obraz = "hosomakiGotowe.png"; break;
                case "Futomaki": obraz = "futomakiGotowe.png"; break;
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
