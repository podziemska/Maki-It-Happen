using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Maki_it_happen
{
    public static class GameState
    {
        public static int Kasa { get; set; } = 100;
        public static int IloscRyzu { get; set; } = 10;
        public static int IloscRyby { get; set; } = 5;
        public static int IloscOgorka { get; set; } = 8;
        public static int IloscNori { get; set; } = 12;
        public static int OnigiriCount { get; set; }
        public static int NigiriCount { get; set; }
        public static int HosomakiCount { get; set; }
        public static int FutomakiCount { get; set; }
        public static int BestTime { get; set; } = 10000; // liczik czasu nie działą w profilu
        public static string LastSushi { get; set; } = "";
        public static string CurrentOrder { get; set; } = "";

        public static int poziom_trudnosci { get; set; } = 1;
        public static int limit_czasu_sek { get; set; } = 100;
        public static int LiczbaKlientow { get; set; } = 0;
        public static int punkty { get; set; } = 0;

    }


    public partial class GameWindow : Window
    {
        private int timeElapsed = 0;
        private System.Windows.Threading.DispatcherTimer timer;

        private int currentStep = 0;
        private List<string> recipe = new List<string>();

        private bool czyDodanoRyz = false;
        private bool czyDodanoNori = false;
        private bool czyDodanoOgorek = false;
        private bool czyDodanoLosos = false;

        private string selectedSushiType = "";

        public SalaGlowna salaRef;


        public GameWindow(SalaGlowna sala)
        {
            InitializeComponent();
            salaRef = sala;
            AktualizujInterfejs();
            StartTimer();
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
                img.Source = new BitmapImage(new Uri($"/images/{nazwa}", UriKind.Relative));
                img.Stretch = Stretch.Fill;
                Grid.SetRowSpan(img, 4);
                MainGrid.Children.Add(img);
                Panel.SetZIndex(img, -1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetIngredients()
        {
            czyDodanoRyz = false;
            czyDodanoNori = false;
            czyDodanoOgorek = false;
            czyDodanoLosos = false;
        }

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

        
        private async void PokazGotoweSushi() // niepotrzebna wsm jedynie co dziala to ze znikaja skladniki 
        {
            
            await Task.Delay(2500);
            usun.Content = "Sushi Master zawija sushi, bądź cierpliwy!";
            var doUsuniecia = new List<UIElement>();
            foreach (UIElement child in MainGrid.Children)
            {
                if (child is Image img && img.Source != null && img.Source.ToString().Contains("G.png"))
                    doUsuniecia.Add(child);
            }

            foreach (var img in doUsuniecia)
                MainGrid.Children.Remove(img);
            await Task.Delay(7000);
            usun.Content = "🍣 GOTOWE!";
        }

        private void CheckIfFinished()
        {
            if (currentStep == recipe.Count)
            {
                PokazGotoweSushi();
            }
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
                CheckIfFinished();
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
                CheckIfFinished();
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
                CheckIfFinished();
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
                CheckIfFinished();
            }
        }

        // --- SERWOWANIE ---

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (currentStep != recipe.Count)
            {
                MessageBox.Show("To sushi nie jest jeszcze gotowe!");
                return;
            }

            // zapis
            GameState.LastSushi = selectedSushiType;

            int zarobek = 0;

            switch (selectedSushiType)
            {
                case "Onigiri": zarobek = 30; break;
                case "Nigiri": zarobek = 40; break;
                case "Hosomaki": zarobek = 50; break;
                case "Futomaki": zarobek = 70; break;
            }

            GameState.Kasa += zarobek;

            switch (selectedSushiType)
            {
                case "Onigiri": GameState.OnigiriCount++; break;
                case "Nigiri": GameState.NigiriCount++; break;
                case "Hosomaki": GameState.HosomakiCount++; break;
                case "Futomaki": GameState.FutomakiCount++; break;
            }

            MessageBox.Show($"Zrobiono {selectedSushiType}");
            salaRef.PokazSushi();
            salaRef.AktualizujKase();
            salaRef.Show();
            this.Close();
            if (GameState.BestTime> timeElapsed)
            {
                GameState.BestTime = timeElapsed;
            }

            this.Close();
        }

        private void ResetGameView()
        {
            
            
            var doUsuniecia = MainGrid.Children.OfType<Image>()
                .Where(img => img.Source != null && img.Source.ToString().Contains("G.png"))
                .ToList();

            foreach (var img in doUsuniecia)
            {
                MainGrid.Children.Remove(img);
            }

            
            ResetIngredients(); 
            currentStep = 0;
            recipe.Clear();
            timeElapsed = 0;

            
            czas.Foreground = Brushes.Black;

            
            SushiTypePanel.Visibility = Visibility.Visible;
            IngredientsPanel.Visibility = Visibility.Collapsed;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var doUsuniecia = new List<UIElement>();
            foreach (UIElement child in MainGrid.Children)
                if (child is Image img && img.Source != null && img.Source.ToString().Contains("G.png"))
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
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeElapsed < GameState.limit_czasu_sek)
            {
                timeElapsed++;
                czas.Text = $"⏱ {timeElapsed}s / {GameState.limit_czasu_sek}s";

                if (timeElapsed >= GameState.limit_czasu_sek * 0.50)
                {
                    czas.Foreground = Brushes.Yellow;
                }



                if (timeElapsed >= GameState.limit_czasu_sek * 0.70)
                {
                    czas.Foreground = Brushes.Red;
                }
            }
            else
            {
                // CZAS MINĄŁ
                if (sender is DispatcherTimer timer)
                {
                    timer.Stop();
                }


                GameState.Kasa -= 20;
                KasaLabel.Text = GameState.Kasa.ToString()+" $";
                
                MessageBox.Show(
                    "KONIEC CZASU!\n\nSushi nie zostało dostarczone.\nKlienci są wściekli! Płacisz 20$ kary.",
                    "Limit czasu przekroczony",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                // 3. Resetowanie widoku gry
                ResetGameView();
                usun.Content = "Czas minął!";
            }
        }


        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow oknoSklepu = new ShopWindow(this);
            oknoSklepu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            oknoSklepu.ShowDialog();
        }

        private void OpenSala_Click(object sender, RoutedEventArgs e)
        {
            
            salaRef.Show();
            this.Close();
        }

        private void StartTimer()
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        
        

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
