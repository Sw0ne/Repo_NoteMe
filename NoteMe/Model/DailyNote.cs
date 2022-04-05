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
        public DailyNote(int idDiaryEntry)
        {
            IdDiaryEntry = idDiaryEntry;
            Load();
        }

        // ID_DAILYNOTE
        private int _idDailyNote;
        public int IdDailyNote { get; set; }

        // ID_DIARYENTRY
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

        // NOTECONTENT
        private string _noteContent = ""; // Sobald Objekt DailyNote erzeugt wird, ist NoteContent leer
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

        // METHODE 1: INSERT & UPDATE NOTECONTENT / SAVE
        internal void Save()
        {
            if (IdDailyNote == 0)
            {
                var data = new Dictionary<string, object>
                {
                    {"@NoteContent", NoteContent },
                    {"@IdDiaryEntry", IdDiaryEntry }
                    // Key , Value
                };
                DatabaseConnection.Instance.Write("INSERT INTO dailyNotes (noteContent,idDiaryEntry) VALUES (@NoteContent,@IdDiaryEntry)", data);
            }
            else
            {
                var data = new Dictionary<string, object>
                {
                    {"@NoteContent", NoteContent },
                    {"@IdDailyNote", IdDailyNote }
                    // Key , Value
                };
                DatabaseConnection.Instance.Write("UPDATE diaryEntries SET noteContent = (@NoteContent) WHERE idDailyNote = (@IdDailyNote)", data);
            }
        }

        // METHODE 2: DELETE NOTECONTENT

        // METHODE 3: SELECT NOTECONTENT / LOAD
        internal void Load()
        {
            var data = new Dictionary<string, object> 
            {
                {"@IdDiaryEntry", IdDiaryEntry }
                // Key , Value
            };

            var result = DatabaseConnection.Instance.Read("SELECT * FROM dailyNotes WHERE idDiaryEntry = @IdDiaryEntry", data);

            if (result.Count == 0)
            {
                Console.WriteLine("No note found");
                return;
            }

            NoteContent = result["noteContent"];
            IdDailyNote = int.Parse(result["idDailyNote"]);
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
