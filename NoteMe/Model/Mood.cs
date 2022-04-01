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
        public Mood()
        {

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

        // INOTIFYPROPERTYCHANGED EVENT
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
