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
        public DiaryEntry(User user, CalendarLogic cal)
        {
            _user = user;
            _cal = cal;

            DiaryDate = cal.SelectedDate;

            Load();

            // datum übergeben, wenn da, andere sachen laden und hat id, wenn nicht, dann insert
        }

        // REFERENZ AUF OBJEKT
        private User _user;
        private Mood _mood;
        private DailyNote _dailyNote;
        private TodoList _todoList;
        private CalendarLogic _cal;

        // ID_DIARYENTRY
        public int IdDiaryEntry { get; set; }

        // DIARYDATE
        private DateTime? _diaryDate;
        public DateTime? DiaryDate
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

        // NOTE UM AN DATACONTEXT ZU BINDEN
        public DailyNote Note
        {
            get
            {
                return _dailyNote;
            }
        }

        // METHODE 1: INSERT (& UPDATE) DIARY ENTRY / SAVE
        internal void Save()
        {
            if (IdDiaryEntry == 0)
            {
                var data = new Dictionary<string, object> // string wegen name der spalte
                {
                    {"@IdUser", _user.IdUser  }, 
                    {"@DiaryDate", _diaryDate }
                    // Key , Value
                };

                DatabaseConnection.Instance.Write("INSERT INTO diaryEntries (idUser,diaryDate) VALUES (@IdUser,@DiaryDate);", data);                                                                                                            
            }

            _dailyNote.Save();
            _mood.Save();
        }

        // METHODE 2: DELETE DIARY ENTRY
        string deleteStatement = "DELETE FROM diaryEntries WHERE diaryDate = @DiaryDate";

        // METHODE 4: SELECT DIARY ENTRY / LOAD
        internal void Load()
        {
            var data = new Dictionary<string, object> // string wegen name der spalte
            {
                {"@IdUser", _user.IdUser  }, // User Objekt kennt id
                {"@DiaryDate", _diaryDate }
                // Key , Value
            };

            var result = DatabaseConnection.Instance.Read("SELECT * FROM diaryEntries WHERE diaryDate = @DiaryDate AND idUser = @IdUser;", data);

            if (result.Count == 0)
            {
                Console.WriteLine("Date not found");
                return;
            }

            DiaryDate = DateTime.Parse(result["diaryDate"]);

            var idString = result["idDiaryEntry"];
            IdDiaryEntry = int.Parse(idString);

            _dailyNote = new DailyNote(IdDiaryEntry);
            _todoList = new TodoList(IdDiaryEntry);
            _mood = new Mood(IdDiaryEntry);
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
