using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Maki_it_happen;

    public partial class GameWindow : Window
    {
        public int IloscRyzu = 0;
        public int IloscRyby = 5;
        public int IloscOgorka = 8;
        public int IloscNori = 12;
        public int Kasa = 100; // Przykładowa ilość pieniędzy, którą gracz ma na start


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

            if (IloscRyzu > 0)
            {
                Image riceImage = new Image();
                riceImage.Source = new BitmapImage(new Uri("/ryz.png", UriKind.Relative));

                riceImage.Width = 450;
                riceImage.Height = 90;

                Canvas.SetLeft(riceImage, -125);
                Canvas.SetTop(riceImage, -2);

                SushiLayers.Children.Add(riceImage);
            }
            else
            {
                MessageBox.Show("Nie masz już ryżu! Idź do sklepu, aby kupić więcej.");
            }

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
            ShopWindow oknoSklepu = new ShopWindow(this);
            oknoSklepu.ShowDialog(); // ShowDialog blokuje kuchnię, póki nie zamkniesz sklepu
        }

        private void ShowIngredients()
        {
            SushiTypePanel.Visibility = Visibility.Collapsed;
            IngredientsPanel.Visibility = Visibility.Visible;

            
            RiceButton.Visibility = Visibility.Visible;
            FishButton.Visibility = Visibility.Visible;
            CucumberButton.Visibility = Visibility.Visible;
            NoriButton.Visibility = Visibility.Visible;

            
            if (selectedSushiType == "Onigiri")
            {
               
                CucumberButton.Visibility = Visibility.Collapsed;
            }

            if (selectedSushiType == "Nigiri")
            {
                CucumberButton.Visibility = Visibility.Collapsed;
                NoriButton.Visibility = Visibility.Collapsed;
            }

            if (selectedSushiType == "Hosomaki")
            {
                CucumberButton.Visibility = Visibility.Collapsed;
            }

            
        }
        private string selectedSushiType = "";

        private void Onigiri_Click(object sender, RoutedEventArgs e)
        {
            selectedSushiType = "Onigiri";
            ShowIngredients();
        }

        private void Nigiri_Click(object sender, RoutedEventArgs e)
        {
            selectedSushiType = "Nigiri";
            ShowIngredients();
        }

        private void Hosomaki_Click(object sender, RoutedEventArgs e)
        {
            selectedSushiType = "Hosomaki";
            ShowIngredients();
        }

        private void Futomaki_Click(object sender, RoutedEventArgs e)
        {
            selectedSushiType = "Futomaki";
            ShowIngredients();
        }
    }

