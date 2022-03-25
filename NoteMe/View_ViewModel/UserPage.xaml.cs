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
        public UserPage()
        {
            InitializeComponent();
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();
        }

        private void NeuesKontoPasstSo_Click(object sender, RoutedEventArgs e)
        {
            // Erstellen von Bindings zur Benutzereingabe bei der Erstellung eines neuen Users (von View abgegrenzt, also nicht einfach z.B. Text = "{Binding Model.User.vorname}", oder ist das besser?)

            Binding bindingInputVorname = new Binding("Text");
            bindingInputVorname.Source = inputVorname;
            bindingInputVorname.Mode = BindingMode.TwoWay;

            Binding bindingInputNachname = new Binding("Text");
            bindingInputNachname.Source = inputNachname;
            bindingInputNachname.Mode = BindingMode.TwoWay;

            Binding bindingInputWunschUsername = new Binding("Text");
            bindingInputWunschUsername.Source = inputWunschUsername;
            bindingInputWunschUsername.Mode = BindingMode.TwoWay;

            User user = new User(bindingInputNachname, bindingInputNachname, bindingInputWunschUsername); 

            // Zu WelcomeWindow wechseln
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();

        }
    }
}
