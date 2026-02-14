using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maki_it_happen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Graj_Click(object sender, RoutedEventArgs e)
        {
            // 1. Tworzymy instancję nowego okna z kuchnią
            GameWindow oknoGry = new GameWindow();

            // 2. Pokazujemy nowe okno
            oknoGry.Show();

            // 3. Zamykamy obecne menu, żeby nie wisiało w tle
            this.Close();

            //I cyk pyk jesteśmy w kuchni!
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // The Walking Dead
        }
    }
}