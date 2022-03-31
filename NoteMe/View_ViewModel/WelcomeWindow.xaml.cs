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
        public WelcomeWindow() // Passiert wenn Objekt erstellt wird / Konstruktor
        {
            InitializeComponent();

            //var unused = DatabaseConnection.Instance;
            DatabaseConnection myConnection = new DatabaseConnection();
            myConnection.Initialize();
            myConnection.OpenConnection();

            Gruss();
            CheckIfUserInDB();

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }


        private void NeuesKonto_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();

            this.Close();
        }

        private void WeiterButton_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();

            this.Close();
        }

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

        public void CheckIfUserInDB()
        {
            if (GrussBlockName.Text == null) // Eigentlich --> if (databaseconnection.instance.execute("select * from user;") != null) --> Funktionmiert aber nicht, deshalb das als Zwischenlösung
            {
                GrussBlockTageszeit.Visibility = Visibility.Visible;
                GrussBlockName.Visibility = Visibility.Visible;
                WeiterButton.Visibility = Visibility.Visible;
                NeuesKonto.Visibility = Visibility.Hidden;
            }
            else
            {
                GrussBlockTageszeit.Visibility = Visibility.Hidden;
                GrussBlockName.Visibility = Visibility.Hidden;
                WeiterButton.Visibility = Visibility.Visible;
                NeuesKonto.Visibility = Visibility.Visible;
            }
        }
    }
}


