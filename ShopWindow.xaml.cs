using System.Windows;

namespace Maki_it_happen
{
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
        }

        private void BuyRice_Click(object sender, RoutedEventArgs e)
        {
            // TODO: if (Kasa >= 20) { Kasa -= 20; Ryz += 10; }
        }

        private void BuyFish_Click(object sender, RoutedEventArgs e)
        {
            // TODO: if (Kasa >= 50) { Kasa -= 50; Losos += 5; }
        }

        private void BuyNori_Click(object sender, RoutedEventArgs e)
        {
            // TODO: if (Kasa >= 15) { Kasa -= 15; Nori += 20; }
        }

        private void BackToKitchen_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Zamyka tylko sklep i wraca do otwartej kuchni
        }
    }
}