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
using NoteMe.Model;

namespace NoteMe
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            // Datum und Wochentag Anzeige
            var time = DateTime.Today;
            var weekday = time.DayOfWeek;
            DatumBox.Text = weekday + ", " + time.ToShortDateString();

            // Kalender-Datum Default = Heute
            Calendar.SelectedDate = DateTime.Today;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonVor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSpeichern_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLoeschen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ButtonHauptmenu_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();

            this.Close();
        }
    }
}
