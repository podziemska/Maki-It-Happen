using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation; // Wymagane dla Storyboard
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maki_it_happen
{
    /// <summary>
    /// Logika interakcji dla klasy SalaGlowna.xaml
    /// </summary>
    public partial class SalaGlowna : Window
    {
        // Zakładam, że GameState.Kasa jest zdefiniowane w innym pliku
        public int Kasa = GameState.Kasa;

        public SalaGlowna()
        {
            InitializeComponent();
            KasaLabel.Text = $"Kasa:{GameState.Kasa}$$";
        }

        private void Kuchnia_Click(object sender, RoutedEventArgs e)
        {
            GameWindow okno = new GameWindow();

            // Ustawienie startu na środku ekranu
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();
            this.Close(); // Zamyka obecne okno (np. Salę Główną)
        }

        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy i otwieramy nowe okno sklepu
            //ShopWindow oknoSklepu = new ShopWindow();
            //oknoSklepu.ShowDialog(); // ShowDialog blokuje kuchnię, póki nie zamkniesz sklepu
        }

        private static Random rng = new Random();

        // --- Nowa logika dla klientów ---

        // Obsługa kliknięcia przycisku "NOWY KLIENT"
        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            // 1. Zresetuj pozycję klienta (wróć z lewej na prawą)
            KlientTransform.X = 0;

            // 2. Spraw, aby model był w pełni widoczny
            KlientImage.Opacity = 1;

            // Opcjonalnie: Tutaj można by wywołać generowanie losowego zamówienia
            // Zamowienie noweZamowienie = GenerujLosoweZamowienie();
            // MessageBox.Show("Pojawił się nowy klient! Złóż zamówienie.");
        }

        // Obsługa kliknięcia przycisku "ODBIERZ ZAMÓWIENIE"
        private void OdbierzZamowienie_Click(object sender, RoutedEventArgs e)
        {
            // 1. Znajdź animację zdefiniowaną w zasobach XAML
            Storyboard sb = (Storyboard)this.FindResource("KlientDoKolejkiStoryboard");

            // 2. Uruchom animację
            if (sb != null)
            {
                sb.Begin();
                // Opcjonalnie: Dodaj kasę po pomyślnym odebraniu zamówienia
                // GameState.Kasa += 10; // Przykładowa kwota
                // KasaLabel.Text = $"Kasa:{GameState.Kasa}$$";
            }
        }
    }
}