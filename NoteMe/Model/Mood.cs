using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class Mood : INotifyPropertyChanged
    {
        // KONSTRUKTOR
        public Mood(int idDiaryEntry)
        {
            IdDiaryEntry = idDiaryEntry;
        }

        // ID_MOOD
        private int _idMood;
        public int IdMood { get; set; }

        // ID_DIARYENTRY
        private int _idDiaryEntry;
        public int IdDiaryEntry { get; set; }

        // MOODTYPE
        private byte _moodType;
        public byte MoodType
        {
            get
            {
                return _moodType;
            }
            set
            {
                if(_moodType != value)
                {
                    _moodType = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoodType)));
                }
            }
        }

        // METHODE 1: INSERT MOOD / SAVE
        internal void Save()
        {
            if (IdMood == 0)
            {
                var data = new Dictionary<string, object>
                {
                    {"@MoodType", MoodType },
                    {"@IdDiaryEntry", IdDiaryEntry }
                    // Key , Value
                };

                DatabaseConnection.Instance.Write("INSERT INTO moods (moodType,idDiaryEntry) VALUES (@MoodType,@IdDiaryEntry)", data);
            }
            else
            {
                var data = new Dictionary<string, object>
                {
                    {"@MoodType", MoodType },
                    {"@IdMood", IdMood }
                    // Key , Value
                };
                DatabaseConnection.Instance.Write("UPDATE moods SET moodType = (@MoodType) WHERE idMood = (@IdMood)", data);
            }
        }

        // METHODE 2: DELETE MOOD

        // METHODE 3: UPDATE MOOD

        // METHODE 4: SELECT MOOD / LOAD
        internal void Load()
        {
            var data = new Dictionary<string, object> // string wegen name der spalte
            {
                {"@MoodType", MoodType },
                {"@IdDiaryEntry", IdDiaryEntry }
                // Key , Value
            };

            var result = DatabaseConnection.Instance.Read("SELECT * FROM moods WHERE idDiaryEntry = @IdDiaryEntry", data);

            if (result.Count == 0)
            {
                Console.WriteLine("No mood saved");
                return;
            }
        }

        // INOTIFYPROPERTYCHANGED-EVENT
        public event PropertyChangedEventHandler PropertyChanged;

        /*
         * 
         *              `idMood`            INT             NOT NULL AUTO_INCREMENT,
                `moodType`          TINYINT(10)     NOT NULL,
                `idDiaryEntry`      INT  
         * 
         * 
         */
    }
}
