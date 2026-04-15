using System.Configuration;
using System.Data;
using System.Windows;

namespace Maki_it_happen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MusicPlayer.Play("pack://application:,,,/muzyka.mp3");
        }
    }

}
