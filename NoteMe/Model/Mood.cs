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
        // Konstruktor
        public Mood()
        {

        }

        // Fields
        public int IdMood { get; set; }

        public int IdDiaryEntry { get; set; }

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


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
