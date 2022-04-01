using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class DiaryEntry : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public DiaryEntry(User user)
        {
            _user = user;
            // datum übergeben, wenn da, andere sachen laden und hat id, wenn nicht, dann insert
        }

        // REFERENZ AUF USER (STATT USER ID)
        private User _user; // Hier Objekte referenziert, da das hier nicht die DB ist und es hier geht
        private Mood _mood;
        private DailyNote _dailyNote;
        private TodoList _todoList;

        // ID_DIARYENTRY
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

        // DIARYDATE
        private DateTime _diaryDate;
        public DateTime DiaryDate
        {
            get
            {
                return _diaryDate;
            }
            set
            {
                if (_diaryDate != value)
                {
                    _diaryDate = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DiaryDate)));
                }
            }
        }

        // METHODEN
        internal void Save()
        {
            // abfrage ob id diary entry schon da, wenn ja nicht speichern

            var data = new Dictionary<string, object> // string wegen name der spalte
            {
                {"@idDiaryEntry", _idDiaryEntry },
                {"@idUser", _user.IdUser  }, // User Objekt kennt id
                {"@diaryDate", _diaryDate }
                // Key , Value
            };

            DatabaseConnection.Instance.Write("INSERT INTO users (vorname,nachname) VALUES (@Vorname,@Nachname)", data); // into diary entry //nicht neu = update (unterscheidung)
            // felder mood etc übergeben
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
