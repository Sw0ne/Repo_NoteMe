
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private User _user;

        // KONSTRUKTOR: USER WINDOW
        public UserWindow()
        {
            InitializeComponent();

            _user = new User();
            this.DataContext = _user;
        }

        // DASBINICH-BUTTON-CLICKEVENT
        private void DasBinIchButton_Click(object sender, RoutedEventArgs e)
        {
            _user.Save();

            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

            this.Close();
        }

        // HELP-BUTTON-CLICKEVENT
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            if (HelpBeschreibungTextBlock.Visibility == Visibility.Hidden)
            {
                HelpBeschreibungTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                HelpBeschreibungTextBlock.Visibility = Visibility.Hidden;
            }
        }

        // ABBRECHEN-BUTTON-CLICKEVENT
        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

            this.Close();
        }

        // WINDOW-MOUSEDOWN-MOUSEDOWNEVENT (VERSCHIEBEN DES FENSTERS)
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        // BUTTONEXIT-CLICKEVENT (SCHLIESSEN DES FENSTERS)
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
