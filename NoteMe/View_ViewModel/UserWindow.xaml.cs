
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

        public UserWindow()
        {
            InitializeComponent();

            _user = new User();
            this.DataContext = _user;
        }

        private void DasBinIchButton_Click(object sender, RoutedEventArgs e)
        {
            //inputVorname.Text = _user.Vorname;
            //inputNachname.Text = _user.Nachname;
            //Console.WriteLine($"Name: {_user.Vorname} {_user.Nachname}");
            _user.Save();

            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

            this.Close();
        }

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

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
