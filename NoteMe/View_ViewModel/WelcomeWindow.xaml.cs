using NoteMe.Model;
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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace NoteMe
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        // KONSTRUKTOR: WELCOME WINDOW
        public WelcomeWindow() 
        {
            InitializeComponent();

            Gruss();
            CheckIfUserInDB();
        }

        // BUTTONEXIT-CLICKEVENT (SCHLIESSEN DES FENSTERS)
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // WINDOW-MOUSEDOWN-MOUSEDOWNEVENT (VERSCHIEBEN DES FENSTERS)
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        // NEUESKONTO-BUTTON-CLICKEVENT
        private void NeuesKonto_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();

            this.Close();
        }

        // WEITER-BUTTON-CLICKEVENT
        private void WeiterButton_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();

            this.Close();
        }

        // ANZEIGE DES GRUSSES (JE NACH TAGESZEIT)
        public void Gruss()
        {
            if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 12)
            {
                GrussBlockTageszeit.Text = "Guten Morgen, ";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
            {
                GrussBlockTageszeit.Text = "Guten Mittag, ";
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
            {
                GrussBlockTageszeit.Text = "Guten Abend, ";
            }
            else
            {
                GrussBlockTageszeit.Text = "Gute Nacht, ";
            }
        }

        // ANZEIGE BESTIMMTER BUTTONS / TEXTFELDER, WENN BEREITS USER EXISTIERT, ANDERNFALLS ANZEIGE ANDERER ELEMENTE ZUR KONTOERSTELLUNG
        public void CheckIfUserInDB()
        {
            var user = new User();

            user.Load();

            if (string.IsNullOrEmpty(user.Vorname))
            {
                GrussBlockTageszeit.Visibility = Visibility.Hidden;
                GrussBlockName.Visibility = Visibility.Hidden;
                WeiterButton.Visibility = Visibility.Hidden;
                NeuesKonto.Visibility = Visibility.Visible;
            }
            else
            {
                this.DataContext = user;

                GrussBlockTageszeit.Visibility = Visibility.Visible;
                GrussBlockName.Visibility = Visibility.Visible;
                WeiterButton.Visibility = Visibility.Visible;
                NeuesKonto.Visibility = Visibility.Hidden;
            }
        }
    }
}


