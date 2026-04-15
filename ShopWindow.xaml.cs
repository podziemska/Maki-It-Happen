using System.Windows;

namespace Maki_it_happen
{
    public partial class ShopWindow : Window
    {
        private GameWindow _GW;

        // Konstruktor przyjmuje GameWindow, żeby móc wywołać odświeżenie interfejsu
        public ShopWindow(GameWindow gameWindow)
        {
            InitializeComponent();
            _GW = gameWindow;
            nori_cena.Text = (15 * GameState.poziom_trudnosci).ToString();
            ryz_cena.Text = (20 * GameState.poziom_trudnosci).ToString();
            losos_cena.Text = (25 * GameState.poziom_trudnosci).ToString();
            ogorek_cena.Text = (10 * GameState.poziom_trudnosci).ToString();
            

        }

        private void BuyRice_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Kasa >= 20*GameState.poziom_trudnosci)
            {
                GameState.Kasa -= 20 * GameState.poziom_trudnosci;
                GameState.IloscRyzu += 10;
                AktualizujWidok();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco pieniędzy!");
            }
        }

        private void BuyFish_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Kasa >= 25 * GameState.poziom_trudnosci)
            {
                GameState.Kasa -= 25 * GameState.poziom_trudnosci;
                GameState.IloscRyby += 5;
                AktualizujWidok();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco pieniędzy!");
            }
        }

        private void BuyNori_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Kasa >= 15 * GameState.poziom_trudnosci)
            {
                GameState.Kasa -= 15 * GameState.poziom_trudnosci;
                GameState.IloscNori += 20;
                AktualizujWidok();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco pieniędzy!");
            }
        }

        private void BuyCucumber_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Kasa >= 10 * GameState.poziom_trudnosci)
            {
                GameState.Kasa -= 10 * GameState.poziom_trudnosci;
                GameState.IloscOgorka += 8;
                AktualizujWidok();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco pieniędzy!");
            }
        }

        // Metoda pomocnicza, która odświeża napisy w oknie kuchni
        private void AktualizujWidok()
        {
            // Wywołujemy publiczną metodę z GameWindow, którą przygotowaliśmy wcześniej
            _GW.AktualizujInterfejs();
        }

        private void BackToKitchen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}