using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Maki_it_happen
{
    public partial class SalaGlowna : Window
    {
        // Flaga sprawdzająca, czy klient aktualnie czeka
        private bool czyKlientCzeka = false;

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

        // Zmieniono na PUBLIC, aby GameWindow mógł wywołać tę metodę
        public void OdbierzZamowienie_Click(object sender, RoutedEventArgs e)
        {
            // Szukamy animacji w zasobach XAML
            Storyboard sb = (Storyboard)this.FindResource("KlientOdchodziAnimacja");

            if (sb != null)
            {
                sb.Begin();

                // Resetujemy stan klienta
                czyKlientCzeka = false;
                OdbierzBtn.IsEnabled = false;

                // Odświeżamy wyświetlanie kasy (pieniądze dodało już GameWindow)
                AktualizujKase();
            }
        }

        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            if (czyKlientCzeka)
            {
                MessageBox.Show("Przy ladzie już stoi klient!");
                return;
            }

            // KLUCZOWE: Resetujemy transformację X do 0, aby klient 
            // zawsze zaczynał od lewej krawędzi (lub startowej pozycji)
            KlientTransform.X = 0;
            KlientImage.Opacity = 1;

            czyKlientCzeka = true;
            OdbierzBtn.IsEnabled = true;
        }

        private void Kuchnia_Click(object sender, RoutedEventArgs e)
        {
            GameWindow okno = new GameWindow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide(); // Używamy Hide zamiast Close, jeśli chcemy wrócić do tej samej sali
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
