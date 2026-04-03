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
        private int currentStep = 0;
        private List<string> recipe = new List<string>();

        //BLANKA SĄ NA FALSE!!!! abys pamietala
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

        public void AktualizujInterfejs()
        {
            KasaLabel.Text = $"KASA: {GameState.Kasa}$";
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
            catch { }
        }

        
        private void ResetIngredients()
        {
            czyDodanoRyz = false;
            czyDodanoNori = false;
            czyDodanoOgorek = false;
            czyDodanoLosos = false;
        }

        //kolejnosc
        private bool CanAdd(string ingredient)
        {
            if (recipe == null || recipe.Count == 0)
            {
                MessageBox.Show("Najpierw wybierz typ sushi!");
                return false;
            }

            if (currentStep >= recipe.Count)
                return false;

            if (recipe[currentStep] != ingredient)
            {
                MessageBox.Show($"Teraz powinieneś dodać: {recipe[currentStep]}");
                return false;
            }

            return true;
        }

        // --- SKŁADNIKI ---

        private void AddRice_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAdd("Rice")) return;

            if (GameState.IloscRyzu > 0)
            {
                GameState.IloscRyzu--;
                DodajObrazek("RyzG.png");
                czyDodanoRyz = true;
                currentStep++;
                AktualizujInterfejs();
            }
        }

        private void AddFish_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAdd("Fish")) return;

            if (GameState.IloscRyby > 0)
            {
                GameState.IloscRyby--;
                DodajObrazek("LososG.png");
                czyDodanoLosos = true;
                currentStep++;
                AktualizujInterfejs();
            }
        }

        private void AddCucumber_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAdd("Cucumber")) return;

            if (GameState.IloscOgorka > 0)
            {
                GameState.IloscOgorka--;
                DodajObrazek("OgorekG.png");
                czyDodanoOgorek = true;
                currentStep++;
                AktualizujInterfejs();
            }
        }

        private void AddNori_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAdd("Nori")) return;

            if (GameState.IloscNori > 0)
            {
                GameState.IloscNori--;
                DodajObrazek("NoriG.png");
                czyDodanoNori = true;
                currentStep++;
                AktualizujInterfejs();
            }
        }

        // --- SERWOWANIE ---

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            if (currentStep != recipe.Count)
            {
                MessageBox.Show("To sushi nie jest jeszcze gotowe!");
                return;
            }

            bool sukces = false;
            int zarobek = 0;

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

                SalaGlowna sala = new SalaGlowna();
                sala.Show();
                sala.OdbierzZamowienie_Click(null, null);
                this.Close();
            }
            else
            {
                MessageBox.Show("Złe składniki!");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var doUsuniecia = new List<UIElement>();
            foreach (UIElement child in MainGrid.Children)
                if (child is Image img && img.Source.ToString().Contains("G.png"))
                    doUsuniecia.Add(child);

            foreach (var img in doUsuniecia)
                MainGrid.Children.Remove(img);

            ResetIngredients();
            currentStep = 0;
            recipe.Clear();

            SushiTypePanel.Visibility = Visibility.Visible;
            IngredientsPanel.Visibility = Visibility.Collapsed;

            usun.Content = "Anulowano";
        }
        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow oknoSklepu = new ShopWindow(this);
            oknoSklepu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            oknoSklepu.ShowDialog();
        }

        private void OpenSala_Click(object sender, RoutedEventArgs e)
        {
            SalaGlowna sala = new SalaGlowna();
            sala.Show();
            this.Close();
        }
        // --- WYBÓR SUSHI ---

        private void ShowIngredients()
        {
            SushiTypePanel.Visibility = Visibility.Collapsed;
            IngredientsPanel.Visibility = Visibility.Visible;

            CucumberButton.Visibility = (selectedSushiType == "Futomaki") ? Visibility.Visible : Visibility.Collapsed;
            NoriButton.Visibility = (selectedSushiType == "Nigiri") ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Onigiri_Click(object sender, RoutedEventArgs e)
        {
            ResetIngredients();
            selectedSushiType = "Onigiri";
            recipe = new List<string> { "Nori", "Rice","Fish" };
            currentStep = 0;
            ShowIngredients();
        }

        private void Nigiri_Click(object sender, RoutedEventArgs e)
        {
            ResetIngredients();
            selectedSushiType = "Nigiri";
            recipe = new List<string> { "Rice", "Fish" };
            currentStep = 0;
            ShowIngredients();
        }

        private void Hosomaki_Click(object sender, RoutedEventArgs e)
        {
            ResetIngredients();
            selectedSushiType = "Hosomaki";
            recipe = new List<string> { "Nori", "Rice", "Fish" };
            currentStep = 0;
            ShowIngredients();
        }

        private void Futomaki_Click(object sender, RoutedEventArgs e)
        {
            ResetIngredients();
            selectedSushiType = "Futomaki";
            recipe = new List<string> { "Nori", "Rice", "Cucumber", "Fish" };
            currentStep = 0;
            ShowIngredients();
        }
    }
}
