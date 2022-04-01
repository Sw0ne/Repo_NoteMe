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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;

namespace NoteMe
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : INotifyPropertyChanged
    {
        private Mood mood;
        private CalendarLogic cal;

        public HomeWindow()
        {
            InitializeComponent();

            //// Kalender-Datum Default = Heute
            //Calendar.SelectedDate = DateTime.Today;

            //// Datum und Wochentag Anzeige
            //var time = Calendar.SelectedDate;
            //DateTime newDateFormat = (DateTime)time;
            //var weekday = newDateFormat.DayOfWeek;
            //DatumBox.Text = weekday + ", " + newDateFormat.ToShortDateString();

            // DATACONTEXT

            var todo = new TodoList();
            TodoBereich.DataContext = todo;

            var note = new DailyNote();
            DailyNotesInput.DataContext = note;

            mood = new Mood();
            MoodTrackerBereich.DataContext = mood;

            cal = new CalendarLogic();
            DatumBox.DataContext = cal;
            Calendar.DataContext = cal;

            cal.HeutigerTagDefaultAnzeige();
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
            // notiz.Save();
            //mood save
            // todo save
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

        //private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //CalendarLogic cal = new CalendarLogic();
        //    //cal.SelectedDateAnzeigeSynchro();
        //}

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime updatedSelectedDate = (DateTime)Calendar.SelectedDate;
            Calendar.DisplayDate = updatedSelectedDate;

            if (IsLoaded && Calendar.DisplayDate != null)
            {
                // Datum und Wochentag Anzeige
                var time = Calendar.DisplayDate;
                var weekday = time.DayOfWeek;
                DatumBox.Text = weekday + ", " + time.ToShortDateString();
            }
        }

        // Buttons Moodtracker (Hässlich aber funktioniert)

        private void MoodTrackerButton1_Click(object sender, RoutedEventArgs e)
        {
            mood.MoodType = 1;

            if (MoodTrackerButton2.Visibility == Visibility.Visible)
            {
                MoodTrackerButton2.Visibility = Visibility.Hidden;
                MoodTrackerButton3.Visibility = Visibility.Hidden;
                MoodTrackerButton4.Visibility = Visibility.Hidden;
                MoodTrackerButton5.Visibility = Visibility.Hidden;
            }
            else
            {
                MoodTrackerButton2.Visibility = Visibility.Visible;
                MoodTrackerButton3.Visibility = Visibility.Visible;
                MoodTrackerButton4.Visibility = Visibility.Visible;
                MoodTrackerButton5.Visibility = Visibility.Visible;
            }
        }

        private void MoodTrackerButton2_Click(object sender, RoutedEventArgs e)
        {
            mood.MoodType = 2;

            if (MoodTrackerButton1.Visibility == Visibility.Visible)
            {
                MoodTrackerButton1.Visibility = Visibility.Hidden;
                MoodTrackerButton3.Visibility = Visibility.Hidden;
                MoodTrackerButton4.Visibility = Visibility.Hidden;
                MoodTrackerButton5.Visibility = Visibility.Hidden;
            }
            else
            {
                MoodTrackerButton1.Visibility = Visibility.Visible;
                MoodTrackerButton3.Visibility = Visibility.Visible;
                MoodTrackerButton4.Visibility = Visibility.Visible;
                MoodTrackerButton5.Visibility = Visibility.Visible;
            }
        }

        private void MoodTrackerButton3_Click(object sender, RoutedEventArgs e)
        {
            mood.MoodType = 3;

            if (MoodTrackerButton2.Visibility == Visibility.Visible)
            {
                MoodTrackerButton2.Visibility = Visibility.Hidden;
                MoodTrackerButton1.Visibility = Visibility.Hidden;
                MoodTrackerButton4.Visibility = Visibility.Hidden;
                MoodTrackerButton5.Visibility = Visibility.Hidden;
            }
            else
            {
                MoodTrackerButton2.Visibility = Visibility.Visible;
                MoodTrackerButton1.Visibility = Visibility.Visible;
                MoodTrackerButton4.Visibility = Visibility.Visible;
                MoodTrackerButton5.Visibility = Visibility.Visible;
            }
        }

        private void MoodTrackerButton4_Click(object sender, RoutedEventArgs e)
        {
            mood.MoodType = 4;

            if (MoodTrackerButton2.Visibility == Visibility.Visible)
            {
                MoodTrackerButton2.Visibility = Visibility.Hidden;
                MoodTrackerButton3.Visibility = Visibility.Hidden;
                MoodTrackerButton1.Visibility = Visibility.Hidden;
                MoodTrackerButton5.Visibility = Visibility.Hidden;
            }
            else
            {
                MoodTrackerButton2.Visibility = Visibility.Visible;
                MoodTrackerButton3.Visibility = Visibility.Visible;
                MoodTrackerButton1.Visibility = Visibility.Visible;
                MoodTrackerButton5.Visibility = Visibility.Visible;
            }
        }

        private void MoodTrackerButton5_Click(object sender, RoutedEventArgs e)
        {
            mood.MoodType = 5;

            if (MoodTrackerButton2.Visibility == Visibility.Visible)
            {
                MoodTrackerButton2.Visibility = Visibility.Hidden;
                MoodTrackerButton3.Visibility = Visibility.Hidden;
                MoodTrackerButton4.Visibility = Visibility.Hidden;
                MoodTrackerButton1.Visibility = Visibility.Hidden;
            }
            else
            {
                MoodTrackerButton2.Visibility = Visibility.Visible;
                MoodTrackerButton3.Visibility = Visibility.Visible;
                MoodTrackerButton4.Visibility = Visibility.Visible;
                MoodTrackerButton1.Visibility = Visibility.Visible;
            }
        }

        public void HideMoodButtonVisibility(int moodType, Button button)
        {
            // Schönere Logik für Mood-Button-Angelegenheit
        }

        // INotifyPropertyChanged Event Handler

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
