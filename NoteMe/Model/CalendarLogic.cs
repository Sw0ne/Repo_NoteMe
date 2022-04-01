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
        public CalendarLogic()
        {
            SelectedDate = DateTime.Today;
        }

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

        //public void SelectedDateAnzeigeSynchro()
        //{
        //    DateTime updatedSelectedDate = (DateTime)SelectedDate;
        //    DisplayDate = updatedSelectedDate;


        //    //if (IsLoaded && DisplayDate != null)
        //    //{
        //        // Datum und Wochentag Anzeige
        //        var time = DisplayDate;
        //        var weekday = time.DayOfWeek;
        //        DatumBoxText = weekday + ", " + time.ToShortDateString();
        //    //}

        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
