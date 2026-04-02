using System;
using System.Windows;
using System.Windows.Media.Animation;

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
    }
}