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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maki_it_happen
{
    /// <summary>
    /// Logika interakcji dla klasy SalaGlowna.xaml
    /// </summary>
    public partial class SalaGlowna : Window
    {
       
        public SalaGlowna()
        {
            InitializeComponent();
        }
        private void Kuchnia(object sender, RoutedEventArgs e)
        {
            GameWindow okno = new GameWindow();
            okno.Show();
            this.Close();
        }
        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy i otwieramy nowe okno sklepu
            //ShopWindow oknoSklepu = new ShopWindow();
            //oknoSklepu.ShowDialog(); // ShowDialog blokuje kuchniê, póki nie zamkniesz sklepu
        }
    }
}
