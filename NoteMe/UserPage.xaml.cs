﻿using System;
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
            WelcomeWindow welcomewindow = new WelcomeWindow();
            welcomewindow.Show();
        }

        private void NeuesKontoPasstSo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
