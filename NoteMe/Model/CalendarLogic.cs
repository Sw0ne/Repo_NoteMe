using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NoteMe.Model
{
    class CalendarLogic : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public CalendarLogic()
        {
            SelectedDate = DateTime.Today;
        }

        // SELECTED DATE
        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDate)));
                }
            }
        }

        // DISPLAY DATE
        private DateTime _displayDate;
        public DateTime DisplayDate
        {
            get
            {
                return _displayDate;
            }
            set
            {
                if (_displayDate != value)
                {
                    _displayDate = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayDate)));
                }
            }
        }

        // DATUMBOX TEXT
        private string _datumBoxText;
        public string DatumBoxText
        {
            get
            {
                return _datumBoxText;
            }
            set
            {
                if(_datumBoxText != value)
                {
                    _datumBoxText = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DatumBoxText)));
                }
            }
        }

        // METHODE 1: DEFAULT ANZEIGE HEUTIGER TAG
        public void HeutigerTagDefaultAnzeige()
        {
            // Kalender-Datum Default = Heute
            SelectedDate = DateTime.Today;
            DisplayDate = DateTime.Today;

            // Datum und Wochentag Anzeige
            var time = SelectedDate;
            DateTime newDateFormat = (DateTime)time;
            var weekday = newDateFormat.DayOfWeek;
            DatumBoxText = weekday + ", " + newDateFormat.ToShortDateString();
        }

        // METHODE 2: SYNCHRONISATION SELECTED DATE & DISPLAY DATE
        public void SelectedDateAnzeigeSynchro(DateTime? selectedDate)
        {
            DateTime updatedSelectedDate = (DateTime)SelectedDate;
            DisplayDate = updatedSelectedDate;


            if (DisplayDate != null)
            {
                // Datum und Wochentag Anzeige
                var time = DisplayDate;
                var weekday = time.DayOfWeek;
                DatumBoxText = weekday + ", " + time.ToShortDateString();
            }

        }

        // METHODE 3: DAY FORWARD
        public void SelectedDateForward()
        {
            SelectedDate = SelectedDate.Value.AddDays(1);
            SelectedDateAnzeigeSynchro(SelectedDate);
        }

        // METHODE 4: DAY BACK
        public void SelectedDateBack()
        {
            SelectedDate = SelectedDate.Value.AddDays(-1);
            SelectedDateAnzeigeSynchro(SelectedDate);
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
