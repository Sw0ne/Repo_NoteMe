using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class DailyNote : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public DailyNote()
        {
            NoteContent = "TestNoteBinding";
        }

        // ID_DAILYNOTE
        private int _idDailyNote;
        public int IdDailyNote { get; set; }

        // ID_DIARYENTRY
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

        // NOTECONTENT
        private string _noteContent;
        public string NoteContent
        {
            get
            {
                return _noteContent;
            }
            set
            {
                if (_noteContent != value)
                {
                    _noteContent = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteContent)));
                }
            }
        }

        // METHODEN
        internal void Save()
        {
            var data = new Dictionary<string, object>
            {
                {"@NoteContent", NoteContent },
                // Key , Value
            };

            DatabaseConnection.Instance.Write("INSERT INTO dailyNotes (noteContent) VALUES (@NoteContent)", data);
        }

        //internal void Load()
        //{
        //    var data = DatabaseConnection.Instance.Read("SELECT * FROM users;");

        //    if (data.Count == 0)
        //    {
        //        return;
        //    }

        //    Vorname = data["vorname"];
        //    Nachname = data["nachname"];
        //}

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
