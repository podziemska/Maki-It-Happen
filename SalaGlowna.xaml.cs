using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Maki_it_happen
{
    public partial class SalaGlowna : Window
    {
        public bool czyKlientCzeka = false;
        private int tutorialStep = 0;

        Random rand = new Random();

        public SalaGlowna()
        {
            InitializeComponent();
            AktualizujKase();
            PokazSushi();
            KlientImage.Source = new BitmapImage(new Uri("/images/klientBlanka.png", UriKind.Relative));
            StartTutorial();


        }
        private void StartTutorial()
        {
            tutorialStep = 1;
            MessageBox.Show("Witaj w Maki it happen! Zacznijmy od podstaw.\n\nKliknij przycisk NOWY KLIENT.");

            NowyKlientBtn.IsEnabled = true;
            OdbierzBtn.IsEnabled = false;
            KuchniaBtn.IsEnabled = false;
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserProfile okno = new UserProfile(this);
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide();
        }
        public void AktualizujKase()
        {
            KasaLabel.Text = $"Kasa: {GameState.Kasa}$";
        }

        private void GenerujZamowienie()
        {
            string[] menu = { "Onigiri", "Nigiri", "Hosomaki", "Futomaki" };
            GameState.CurrentOrder = menu[rand.Next(menu.Length)];
            ZamowienieLabel.Text = $"Zamówienie: {GameState.CurrentOrder}";
        }

        private void NowyKlient_Click(object sender, RoutedEventArgs e)
        {
            if (tutorialStep == 1)
            {
                tutorialStep = 2;
                MessageBox.Show("Świetnie! Klient złożył zamówienie.\n\nTeraz kliknij IDŹ DO KUCHNI, aby przygotować TWOJE 1 SUSHI!!!.");

                NowyKlientBtn.IsEnabled = false;
                KuchniaBtn.IsEnabled = true;
                
            }

            if (czyKlientCzeka)
            {
                MessageBox.Show("Przy ladzie już stoi klient!");
                return;
            }

            KlientImage.Source = new BitmapImage(new Uri("/images/klientBlanka.png", UriKind.Relative));

            czyKlientCzeka = true;
            OdbierzBtn.IsEnabled = true;

            GenerujZamowienie();
        }

        public void OdbierzZamowienie_Click(object sender, RoutedEventArgs e)
        {
            if (tutorialStep == 3)
            {
                tutorialStep = 4;
                MessageBox.Show("Brawo! Obsłużyłaś pierwszego klienta.\n\nSamouczek zakończony, ale pamiętaj klienci nie będą zadowoleni z niewłasciwych zamówień ;). Powodzenia w prowadzeniu restauracji!");

                NowyKlientBtn.IsEnabled = true;
                OdbierzBtn.IsEnabled = true;
                KuchniaBtn.IsEnabled = true;
            }

            if (!czyKlientCzeka) return;

            bool good = (GameState.LastSushi == GameState.CurrentOrder);

            if (good)
            {
                KlientImage.Source = new BitmapImage(new Uri("/images/zadowolony.png", UriKind.Relative));
                GameState.Kasa += 10;
                MessageBox.Show("Klient zadowolony!");
                GameState.LiczbaKlientow++;
                GameState.punkty += 20;

            }
            else
            {
                KlientImage.Source = new BitmapImage(new Uri("/images/niezadowolony.png", UriKind.Relative));
                MessageBox.Show("To nie jest to, co zamawiałem!");
                GameState.LiczbaKlientow++;
                GameState.punkty -= 10;
            }

            GameState.LastSushi = ""; 
            GameState.CurrentOrder = ""; 
                                         

            czyKlientCzeka = false;
            OdbierzBtn.IsEnabled = false;
            ZamowienieLabel.Text = "";
            SushiImage.Source = null;
            AktualizujKase();
            MessageBox.Show("Liczba klientów: " + GameState.LiczbaKlientow);
        }


        private void Kuchnia_Click(object sender, RoutedEventArgs e)
        {
            if (tutorialStep == 2)
            {
                tutorialStep = 3;
                MessageBox.Show("To jest kuchnia! Przygotuj sushi zgodnie z zamówieniem.\n\nGdy skończysz, wróć do sali i kliknij ODBIERZ ZAMÓWIENIE.");
            }

            if (!czyKlientCzeka)
            {
                MessageBox.Show("Najpierw przyjmij zamówienie od klienta!");
                return;
            }

            GameWindow okno = new GameWindow(this);
            okno.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            okno.Show();
            this.Hide();

        }
        public void PokazSushi()
        {
            string obraz = "";

            switch (GameState.LastSushi)
            {
                case "Onigiri": obraz = "onigiriGotowe2.png"; break; 
                case "Nigiri": obraz = "nigiriGotowe2.png"; break; 
                case "Hosomaki": obraz = "hosomakiGotowe2.png"; break; 
                case "Futomaki": obraz = "futomakiGotowe2.png"; break; 
            }

            if (!string.IsNullOrEmpty(obraz))
            {
                SushiImage.Source = new BitmapImage(
                    new Uri($"/images/{obraz}", UriKind.Relative)
                );
            }
        }
    }
}
