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

            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "muzyka.mp3");

            MusicPlayer.Play(path);
        }
    }

}
