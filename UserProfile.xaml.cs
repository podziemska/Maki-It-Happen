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

        private SalaGlowna sala;

        public UserProfile(SalaGlowna salaRef)
        {
            InitializeComponent();
            sala = salaRef;
            AktualizujStatystyki();
        }

        private void AktualizujStatystyki()
        {
            LicznikKlientow.Content = GameState.LiczbaKlientow.ToString();
            onigiriLicznik.Content = GameState.OnigiriCount; 
            nigiriLicznik.Content = GameState.NigiriCount;
            hosomakiLicznik.Content = GameState.HosomakiCount;
            futomakiLicznik.Content = GameState.FutomakiCount;
            punkty.Content = GameState.punkty;
           if (GameState.BestTime == 10000)
        {
            LicznikCzasu.Content = " ";
        }
        else if (GameState.BestTime == 0) {
            LicznikCzasu.Content = " ";
        }
        else
        {
            LicznikCzasu.Content = GameState.BestTime + " s";
        }
        }

        
        private void powrot(object sender, RoutedEventArgs e)
        {
            sala.Show();
            this.Close();
        }
    }
}
