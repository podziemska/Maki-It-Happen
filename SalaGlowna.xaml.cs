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

private Zamowienie GenerujLosoweZamowienie()
{
    List<Product> produkty = new List<Product>()
    {
        new Sushi("California", 22, 1),
        new Sushi("Philadelphia", 24, 2),
        new Sushi("Ebi", 26, 3),
        new Drink("Cola", 8, 4),
        new Drink("Sprite", 8, 5),
        new Drink("Herbata", 6, 6)
    };

    int ile = rng.Next(1, 5);
    List<Product> wybrane = new List<Product>();

    for (int i = 0; i < ile; i++)
    {
        var p = produkty[rng.Next(produkty.Count)];

        // ZMIEN
        wybrane.Add(new Product(p.Nazwa, p.Cena, p.Id));
    }

    return new Zamowienie()
    
    {
        //  zmien
        Produkty = wybrane
    };
}


    }
}
