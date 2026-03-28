using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Maki_it_happen;
public static class GameState
{
    // Wartość początkowa ustawiana tylko raz przy starcie aplikacji
    public static int Kasa { get; set; } = 100;
}
public partial class GameWindow : Window
    {
    //BLANKA SĄ NA FALSE JC!!!!!!!!!!!!
    private bool czyDodanoRyz = false;
    private bool czyDodanoNori = false;
    private bool czyDodanoOgorek = false;
    private bool czyDodanoLosos = false;
    
        public int IloscRyzu = 10;
        public int IloscRyby = 5;
        public int IloscOgorka = 8;
        public int IloscNori = 12;
 
        public int Kasa = GameState.Kasa;
    public enum EtapSushi
    {
        Start,
        Nori,
        Ryz,
        Ogorek,
        Losos,
        Gotowe
    }
    private EtapSushi aktualnyEtap = EtapSushi.Start;
    public GameWindow()
        {
            InitializeComponent();
        
            
            KasaLabel.Text = $"Kasa: {GameState.Kasa}$$";
    }

    private void AddRice_Click(object sender, RoutedEventArgs e)
    {
        if (czyDodanoRyz)
        {
            MessageBox.Show("Już dodałaś ryż!");
            return;
        }
        if (aktualnyEtap != EtapSushi.Start && aktualnyEtap != EtapSushi.Nori)
        {
            MessageBox.Show("Nie możesz teraz dodać ryżu!");
            return;
        }
        czyDodanoRyz = true;

        aktualnyEtap = EtapSushi.Ryz;

        usun.Content = "ryż";


        if (IloscRyzu <= 0)
        {
            MessageBox.Show("Nie masz już ryżu!");
            return;
        }

        IloscRyzu--;
        RiceCountLabel.Text = $"Szt: {IloscRyzu}";
        
        Image riceImage = new Image();
        riceImage.Source = new BitmapImage(
        new Uri("pack://application:,,,/images/RyzG.png"));

        riceImage.Stretch = Stretch.Fill;
        Grid.SetRowSpan(riceImage, 4);
        MainGrid.Children.Add(riceImage);
        Panel.SetZIndex(riceImage, -1);

    }

    private void AddFish_Click(object sender, RoutedEventArgs e)
    {
        if (czyDodanoLosos)
        {
            MessageBox.Show("Już dodałaś łososia!");
            return;
        }
        if (aktualnyEtap != EtapSushi.Ryz && aktualnyEtap != EtapSushi.Ogorek)
        {
            MessageBox.Show("Najpierw dodaj ryż!");
            return;
        }

        aktualnyEtap = EtapSushi.Losos;
        czyDodanoLosos = true;

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

        Image fishImage = new Image();
        fishImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/LososG.png", UriKind.Absolute));

        fishImage.Stretch = Stretch.Fill;
        Grid.SetRowSpan(fishImage, 4);
        MainGrid.Children.Add(fishImage);
        Panel.SetZIndex(fishImage, -1);
    }

    private void AddCucumber_Click(object sender, RoutedEventArgs e)
    {
        if (czyDodanoOgorek)
        {
            MessageBox.Show("Już dodałaś ogórek!");
            return;
        }

        if (aktualnyEtap != EtapSushi.Ryz)
        {
            MessageBox.Show("Najpierw dodaj ryż!");
            return;
        }

        aktualnyEtap = EtapSushi.Ogorek;
        czyDodanoOgorek = true;
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

        Image cucumberImage = new Image();
        cucumberImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/OgorekG.png", UriKind.Absolute));

        cucumberImage.Stretch = Stretch.Fill;
        Grid.SetRowSpan(cucumberImage, 4);
        MainGrid.Children.Add(cucumberImage);
        Panel.SetZIndex(cucumberImage, -1);
    }

    private void AddNori_Click(object sender, RoutedEventArgs e)
    {
        if (czyDodanoNori)
        {
            MessageBox.Show("Już dodałaś nori!");
            return;
        }

        if (aktualnyEtap != EtapSushi.Start)
        {
            MessageBox.Show("Najpierw musisz zacząć od nori!");
            return;
        }


        aktualnyEtap = EtapSushi.Nori;
        czyDodanoNori = true;

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

        Image noriImage = new Image();
        noriImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/NoriG.png", UriKind.Absolute));

        noriImage.Stretch = Stretch.Fill;
        Grid.SetRowSpan(noriImage, 4);
        MainGrid.Children.Add(noriImage);
        Panel.SetZIndex(noriImage, -1);
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

        private void OpenSala_Click(object sender, RoutedEventArgs e)
        {
        SalaGlowna oknoSala = new SalaGlowna();
        
        //liczenie renczne czy cos
        oknoSala.WindowStartupLocation = WindowStartupLocation.Manual;

        // Obliczanie środka w "procentach" (50% szerokości ekranu - 50% szerokości okna)
        double screenWidth = SystemParameters.PrimaryScreenWidth;
        double screenHeight = SystemParameters.PrimaryScreenHeight;

        oknoSala.Left = (screenWidth / 2) - (oknoSala.Width / 2);
        oknoSala.Top = (screenHeight / 2) - (oknoSala.Height / 2);

        oknoSala.Show();
        this.Hide();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) // nie dziala!
    {
        MainGrid.Children.RemoveRange(0, MainGrid.Children.Count);

        czyDodanoRyz = false;
        czyDodanoNori = false;
        czyDodanoOgorek = false;
        czyDodanoLosos = false;

        aktualnyEtap = EtapSushi.Start;

        usun.Content = "anulowano";
    }
}

