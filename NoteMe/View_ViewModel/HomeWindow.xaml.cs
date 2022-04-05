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
using System.Text.RegularExpressions;

namespace NoteMe
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : INotifyPropertyChanged
    {
        private Mood _mood;
        private CalendarLogic _cal;
        private DiaryEntry _entry;
        private User _user;
        private DailyNote _note;
        private TodoList _todo;

        // KONSTRUKTOR: HOME WINDOW
        public HomeWindow()
        {
            InitializeComponent();
            toggleButtonArray = new ToggleButton[] { MoodTrackerButton1, MoodTrackerButton2, MoodTrackerButton3, MoodTrackerButton4, MoodTrackerButton5 };


            // DATACONTEXT

            _user = new User();
            _user.Load();

            _cal = new CalendarLogic();
            DatumBox.DataContext = _cal;
            Calendar.DataContext = _cal;

            _entry = new DiaryEntry(_user, _cal);
            _entry.Load();

            _todo = new TodoList(_entry.IdDiaryEntry);
            TodoBereich.DataContext = _todo;

            DailyNotesInput.DataContext = _entry.Note;

            _mood = new Mood(_entry.IdDiaryEntry);
            MoodTrackerBereich.DataContext = _mood;
            _mood.Load();

            _cal.HeutigerTagDefaultAnzeige();
        }

        // BUTTONEXIT-CLICKEVENT (SCHLIESSEN DES FENSTERS)
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // BUTTONZURUECK-CLICKEVENT (ZU VORHERIGEM TAG NAVIGIEREN)
        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            _cal.SelectedDateBack();
        }

        // BUTTONVOR-CLICKEVENT (ZU NÄCHSTEM TAG NAVIGIEREN)
        private void ButtonVor_Click(object sender, RoutedEventArgs e)
        {
            _cal.SelectedDateForward();
        }

        // BUTTONSPEICHERN-CLICKEVENT (SPEICHERN DES GESAMTEN DIARY ENTRIES)
        private void ButtonSpeichern_Click(object sender, RoutedEventArgs e)
        {
            _entry.Save();
            // todo save
        }

        // BUTTONLOESCHEN-CLICKEVENT (LÖSCHEN DES GESAMTEN DIARY ENTRIES)
        private void ButtonLoeschen_Click(object sender, RoutedEventArgs e)
        {

        }

        // WINDOW-MOUSEDOWN-MOUSEDOWNEVENT (VERSCHIEBEN DES FENSTERS)
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        // BUTTONHAUPTMENU-CLICKEVENT (ZURÜCK ZUM HAUPTMENÜ / WELCOME WINDOW)
        private void ButtonHauptmenu_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();

            this.Close();
        }

        // EVENT: IN CALENDER AUSGEWÄHLTES DATUM ÄNDERT SICH
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _cal.SelectedDateAnzeigeSynchro(_cal.SelectedDate);
            _entry = new DiaryEntry(_user, _cal);

            DailyNotesInput.DataContext = _entry.Note;
        }

        // MOODTRACKERBUTTON-CLICKEVENT
        private void MoodTrackerButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButtonPressed = sender as ToggleButton;
            string tagAlsString = toggleButtonPressed.Tag.ToString();
            byte tag = Convert.ToByte(tagAlsString);

            _mood.MoodType = tag;
            HideMoodButtonVisibilityJan(toggleButtonPressed);

            Console.WriteLine(_mood.MoodType);
        }

        private ToggleButton[] toggleButtonArray;

        public void HideMoodButtonVisibilityJan(ToggleButton toggleButtonPressed)
        {
            bool isChecked = toggleButtonPressed.IsChecked.HasValue ? toggleButtonPressed.IsChecked.Value : false;

            foreach (var button in toggleButtonArray)
            {
                button.Visibility = button == toggleButtonPressed || !isChecked ? Visibility.Visible : Visibility.Hidden;
            }
        }

        // MOOD-BUTTONS VERSTECKEN (HÄSSLICH ABER FUNKTIONIERT) --> Binding MoodType????
        public void HideMoodButtonVisibility(byte tag, ToggleButton toggleButtonPressed)
        {
            if (toggleButtonPressed.IsChecked == true)
            {
                switch (tag)
                {
                    case 1:
                        _mood.MoodType = 1;

                        MoodTrackerButton2.IsChecked = false;
                        MoodTrackerButton2.Visibility = Visibility.Hidden;

                        MoodTrackerButton3.IsChecked = false;
                        MoodTrackerButton3.Visibility = Visibility.Hidden;

                        MoodTrackerButton4.IsChecked = false;
                        MoodTrackerButton4.Visibility = Visibility.Hidden;

                        MoodTrackerButton5.IsChecked = false;
                        MoodTrackerButton5.Visibility = Visibility.Hidden;

                        break;

                    case 2:
                        _mood.MoodType = 2;

                        MoodTrackerButton1.IsChecked = false;
                        MoodTrackerButton1.Visibility = Visibility.Hidden;

                        MoodTrackerButton3.IsChecked = false;
                        MoodTrackerButton3.Visibility = Visibility.Hidden;

                        MoodTrackerButton4.IsChecked = false;
                        MoodTrackerButton4.Visibility = Visibility.Hidden;

                        MoodTrackerButton5.IsChecked = false;
                        MoodTrackerButton5.Visibility = Visibility.Hidden;

                        break;

                    case 3:
                        _mood.MoodType = 3;

                        MoodTrackerButton1.IsChecked = false;
                        MoodTrackerButton1.Visibility = Visibility.Hidden;

                        MoodTrackerButton2.IsChecked = false;
                        MoodTrackerButton2.Visibility = Visibility.Hidden;

                        MoodTrackerButton4.IsChecked = false;
                        MoodTrackerButton4.Visibility = Visibility.Hidden;

                        MoodTrackerButton5.IsChecked = false;
                        MoodTrackerButton5.Visibility = Visibility.Hidden;

                        break;

                    case 4:
                        _mood.MoodType = 4;

                        MoodTrackerButton1.IsChecked = false;
                        MoodTrackerButton1.Visibility = Visibility.Hidden;

                        MoodTrackerButton2.IsChecked = false;
                        MoodTrackerButton2.Visibility = Visibility.Hidden;

                        MoodTrackerButton3.IsChecked = false;
                        MoodTrackerButton3.Visibility = Visibility.Hidden;

                        MoodTrackerButton5.IsChecked = false;
                        MoodTrackerButton5.Visibility = Visibility.Hidden;

                        break;

                    case 5:
                        _mood.MoodType = 5;

                        MoodTrackerButton1.IsChecked = false;
                        MoodTrackerButton1.Visibility = Visibility.Hidden;

                        MoodTrackerButton2.IsChecked = false;
                        MoodTrackerButton2.Visibility = Visibility.Hidden;

                        MoodTrackerButton3.IsChecked = false;
                        MoodTrackerButton3.Visibility = Visibility.Hidden;

                        MoodTrackerButton4.IsChecked = false;
                        MoodTrackerButton4.Visibility = Visibility.Hidden;

                        break;
                }
            }
            else if (toggleButtonPressed.IsChecked == false)
            {
                switch (tag)
                {
                    case 1:
                        _mood.MoodType = 0;
                        MoodTrackerButton2.Visibility = Visibility.Visible;
                        MoodTrackerButton3.Visibility = Visibility.Visible;
                        MoodTrackerButton4.Visibility = Visibility.Visible;
                        MoodTrackerButton5.Visibility = Visibility.Visible;
                        break;

                    case 2:
                        _mood.MoodType = 0;
                        MoodTrackerButton1.Visibility = Visibility.Visible;
                        MoodTrackerButton3.Visibility = Visibility.Visible;
                        MoodTrackerButton4.Visibility = Visibility.Visible;
                        MoodTrackerButton5.Visibility = Visibility.Visible;
                        break;

                    case 3:
                        _mood.MoodType = 0;
                        MoodTrackerButton1.Visibility = Visibility.Visible;
                        MoodTrackerButton2.Visibility = Visibility.Visible;
                        MoodTrackerButton4.Visibility = Visibility.Visible;
                        MoodTrackerButton5.Visibility = Visibility.Visible;
                        break;

                    case 4:
                        _mood.MoodType = 0;
                        MoodTrackerButton1.Visibility = Visibility.Visible;
                        MoodTrackerButton2.Visibility = Visibility.Visible;
                        MoodTrackerButton3.Visibility = Visibility.Visible;
                        MoodTrackerButton5.Visibility = Visibility.Visible;
                        break;

                    case 5:
                        _mood.MoodType = 0;
                        MoodTrackerButton1.Visibility = Visibility.Visible;
                        MoodTrackerButton2.Visibility = Visibility.Visible;
                        MoodTrackerButton3.Visibility = Visibility.Visible;
                        MoodTrackerButton4.Visibility = Visibility.Visible;
                        break;
                }
            }

            else if (MoodTrackerButton1.IsChecked == false && MoodTrackerButton2.IsChecked == false && MoodTrackerButton3.IsChecked == false && MoodTrackerButton4.IsChecked == false && MoodTrackerButton5.IsChecked == false)
            {
                _mood.MoodType = 0;
            }
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
