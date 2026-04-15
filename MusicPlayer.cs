using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Maki_it_happen
{
    public static class MusicPlayer
    {
        private static MediaPlayer player = new MediaPlayer();

        public static void Play(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("Nie znaleziono pliku: " + path);
                return;
            }

            player.Open(new Uri(path, UriKind.Absolute));
            player.Volume = 1.0; // max głośność

            player.MediaEnded += (s, e) =>
            {
                player.Position = TimeSpan.Zero;
                player.Play();
            };

            player.Play();
        }

        public static void Stop()
        {
            player.Stop();
        }
    }
}
