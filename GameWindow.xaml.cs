using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Maki_it_happen
{
    public static class GameState
    {
        public static int Kasa { get; set; } = 100;
        public static int IloscRyzu { get; set; } = 10;
        public static int IloscRyby { get; set; } = 5;
        public static int IloscOgorka { get; set; } = 8;
        public static int IloscNori { get; set; } = 12;
    }
    public partial class GameWindow : Window
    {
        // Flagi składników dla aktualnej porcji
        private bool czyDodanoRyz = false;
        private bool czyDodanoNori = false;
        private bool czyDodanoOgorek = false;
        private bool czyDodanoLosos = false;

        private string selectedSushiType = "";

        public GameWindow()
        {
            InitializeComponent();
            AktualizujInterfejs();
        }

        // Metoda odświeżająca teksty w widoku XAML
        public void AktualizujInterfejs()
        {
            // Naprawa błędu: KasaLabel teraz pobiera dane z GameState
            KasaLabel.Text = $"KASA: {GameState.Kasa}$";

            // Naprawa błędu: Liczniki pobierają dane z GameState, by zapasy nie wracały po zamknięciu okna
            RiceCountLabel.Text = $"Szt: {GameState.IloscRyzu}";
            FishCountLabel.Text = $"Szt: {GameState.IloscRyby}";
            CucumberCountLabel.Text = $"Szt: {GameState.IloscOgorka}";
            NoriCountLabel.Text = $"Szt: {GameState.IloscNori}";
        }

        private void DodajObrazek(string nazwa)
        {
            Image img = new Image();
            try
            {
                img.Source = new BitmapImage(new Uri($"pack://application:,,,/images/{nazwa}"));
                img.Stretch = Stretch.Fill;
                Grid.SetRowSpan(img, 4);
                MainGrid.Children.Add(img);
                Panel.SetZIndex(img, -1);
            }
            catch { /* Ignoruj błąd jeśli brakuje pliku graficznego */ }
        }

        // --- OBSŁUGA SKŁADNIKÓW ---

        private void AddRice_Click(object sender, RoutedEventArgs e)
        {
            if (czyDodanoRyz) { MessageBox.Show("Ryż już jest na talerzu!"); return; }
            if (GameState.IloscRyzu > 0)
            {
                GameState.IloscRyzu--;
                DodajObrazek("RyzG.png");
                czyDodanoRyz = true;
                AktualizujInterfejs();
                usun.Content = "Dodano ryż";
            }
            else { MessageBox.Show("Brak ryżu!"); }
        }

        private void AddFish_Click(object sender, RoutedEventArgs e)
        {
            if (czyDodanoLosos) return;
            if (GameState.IloscRyby > 0)
            {
                GameState.IloscRyby--;
                DodajObrazek("LososG.png");
                czyDodanoLosos = true;
                AktualizujInterfejs();
                usun.Content = "Dodano łososia";
            }
            else { MessageBox.Show("Brak łososia!"); }
        }

        private void AddCucumber_Click(object sender, RoutedEventArgs e)
        {
            if (czyDodanoOgorek) return;
            if (GameState.IloscOgorka > 0)
            {
                GameState.IloscOgorka--;
                DodajObrazek("OgorekG.png");
                czyDodanoOgorek = true;
                AktualizujInterfejs();
                usun.Content = "Dodano ogórek";
            }
            else { MessageBox.Show("Brak ogórka!"); }
        }

        private void AddNori_Click(object sender, RoutedEventArgs e)
        {
            if (czyDodanoNori) return;
            if (GameState.IloscNori > 0)
            {
                GameState.IloscNori--;
                DodajObrazek("NoriG.png");
                czyDodanoNori = true;
                AktualizujInterfejs();
                usun.Content = "Dodano nori";
            }
            else { MessageBox.Show("Brak nori!"); }
        }

        // --- PRZYCISKI FUNKCYJNE ---

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            bool sukces = false;
            int zarobek = 0;

            // Logika sprawdzania zamówienia
            switch (selectedSushiType)
            {
                case "Onigiri": if (czyDodanoRyz && czyDodanoNori) { sukces = true; zarobek = 30; } break;
                case "Nigiri": if (czyDodanoRyz && czyDodanoLosos) { sukces = true; zarobek = 40; } break;
                case "Hosomaki": if (czyDodanoNori && czyDodanoRyz && czyDodanoLosos) { sukces = true; zarobek = 50; } break;
                case "Futomaki": if (czyDodanoNori && czyDodanoRyz && czyDodanoLosos && czyDodanoOgorek) { sukces = true; zarobek = 70; } break;
            }

            if (sukces)
            {
                GameState.Kasa += zarobek;
                MessageBox.Show($"Wydano {selectedSushiType}! Zarobiłeś {zarobek}$");

                // Powrót do sali i aktywacja animacji odjazdu klienta
                SalaGlowna sala = new SalaGlowna();
                sala.Show();
                sala.OdbierzZamowienie_Click(null, null);
                this.Close();
            }
            else { MessageBox.Show("Złe składniki dla tego typu sushi!"); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Usuwanie obrazków z Gridu
            var doUsuniecia = new List<UIElement>();
            foreach (UIElement child in MainGrid.Children)
                if (child is Image img && img.Source.ToString().Contains("G.png")) doUsuniecia.Add(child);

            foreach (var img in doUsuniecia) MainGrid.Children.Remove(img);

            // Resetowanie flag (składniki zużyte przy anulowaniu nie wracają do magazynu - realizm kuchni!)
            czyDodanoRyz = czyDodanoNori = czyDodanoOgorek = czyDodanoLosos = false;
            SushiTypePanel.Visibility = Visibility.Visible;
            IngredientsPanel.Visibility = Visibility.Collapsed;
            usun.Content = "Anulowano";
        }

        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy nowe okno sklepu i przekazujemy mu aktualną kuchnię (this)
            ShopWindow oknoSklepu = new ShopWindow(this);
            oknoSklepu.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // ShowDialog sprawia, że gracz musi zamknąć sklep, zanim wróci do klikania w kuchni
            oknoSklepu.ShowDialog();
        }

        private void OpenSala_Click(object sender, RoutedEventArgs e)
        {
            SalaGlowna sala = new SalaGlowna();
            sala.Show();
            this.Close();
        }

        // --- WYBÓR TYPU ---

        private void ShowIngredients()
        {
            SushiTypePanel.Visibility = Visibility.Collapsed;
            IngredientsPanel.Visibility = Visibility.Visible;

            // Prosta logika widoczności przycisków
            CucumberButton.Visibility = (selectedSushiType == "Futomaki") ? Visibility.Visible : Visibility.Collapsed;
            NoriButton.Visibility = (selectedSushiType == "Nigiri") ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Onigiri_Click(object sender, RoutedEventArgs e) { selectedSushiType = "Onigiri"; ShowIngredients(); }
        private void Nigiri_Click(object sender, RoutedEventArgs e) { selectedSushiType = "Nigiri"; ShowIngredients(); }
        private void Hosomaki_Click(object sender, RoutedEventArgs e) { selectedSushiType = "Hosomaki"; ShowIngredients(); }
        private void Futomaki_Click(object sender, RoutedEventArgs e) { selectedSushiType = "Futomaki"; ShowIngredients(); }
    }
}