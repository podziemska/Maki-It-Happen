using System.Windows;

namespace Maki_it_happen
{
    public partial class ShopWindow : Window
    {


        private GameWindow _GW;
       

        // Jeden wspólny konstruktor
        public ShopWindow(GameWindow gameWindow)
        {
            InitializeComponent();
            _GW = gameWindow;
            
        }

        private void BuyRice_Click(object sender, RoutedEventArgs e)
        {
            if (_GW.Kasa >= 20)
            {
                _GW.Kasa -= 20;
                _GW.IloscRyzu += 10;
                    _GW.RiceCountLabel.Text = $"Szt: {_GW.IloscRyzu}";
                _GW.KasaLabel.Text = $"Kasa: {_GW.Kasa}";
                
                var sala = Application.Current.Windows.OfType<SalaGlowna>().FirstOrDefault();

                if (sala != null)
                {
                    sala.KasaLabel.Text = $"Kasa: {_GW.Kasa}";
                }


            }
            else
            {
                { MessageBox.Show("Nie masz wystarczająco pieniędzy!"); }
            }
        }

        private void BuyFish_Click(object sender, RoutedEventArgs e)
        {
            if (_GW.Kasa >= 50)
            {
                _GW.Kasa -= 50;
                _GW.IloscRyby += 5;
                _GW.FishCountLabel.Text = $"Szt: {_GW.IloscRyby}";
                _GW.KasaLabel.Text = $"Kasa: {_GW.Kasa}";
            }
            else
            {
                { MessageBox.Show("Nie masz wystarczająco pieniędzy!"); }
            }
        }

        private void BuyNori_Click(object sender, RoutedEventArgs e)
        {
            if (_GW.Kasa >= 15)
            {
                _GW.Kasa -= 15;
                _GW.IloscNori += 20;
                _GW.NoriCountLabel.Text = $"Szt: {_GW.IloscNori}";
                _GW.KasaLabel.Text = $"Kasa: {_GW.Kasa}";
            }
            else
            {
                { MessageBox.Show("Nie masz wystarczająco pieniędzy!"); }
            }
        }

        private void BackToKitchen_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Zamyka tylko sklep i wraca do otwartej kuchni
        }
    }
}