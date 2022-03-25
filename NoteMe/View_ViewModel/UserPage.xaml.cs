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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NoteMe.Model;

namespace NoteMe
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private User _user;

        public UserPage()
        {
            InitializeComponent();

            _user = new User();
            this.DataContext = _user;
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();
        }

        private void NeuesKontoPasstSo_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Nachname: {_user.Nachname}");
            _user.Save();
            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

        }
    }
}
