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
    /// Logika interakcji dla klasy UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        
        public UserProfile()
        {
            InitializeComponent();
            AktualizujStatystyki();
        }

        private void AktualizujStatystyki()
        {
            onigiriLicznik.Content = GameState.OnigiriCount; 
            nigiriLicznik.Content = GameState.NigiriCount;
            hosomakiLicznik.Content = GameState.HosomakiCount;
            futomakiLicznik.Content = GameState.FutomakiCount;
            LicznikCzasu.Content = GameState.BestTime + " s";
        }

        
        private void powrot(object sender, RoutedEventArgs e)
        {
            SalaGlowna okno = new SalaGlowna();

            // Ustawienie okna na œrodku ekranu przed jego pokazaniem
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            okno.Show();

            // Zamykamy obecne okno (np. Menu G³ówne)
            this.Close();
        }
    }
}
