using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class Mood
    {
        // Fields
        private int _idMood;
        private byte _moodType;
        private int _idDiaryEntry;

        // Konstruktor
        public Mood()
        {

        }

        // Properties 
        public int IdMood
        {
            get
            {
                return _idMood;
            }
            set
            {
                _idMood = value;
            }
        }

        public byte MoodType
        {
            get
            {
                return _moodType;
            }
            set
            {
                _moodType = value;
            }
        }

        public int IdDiaryEntry
        {
            get
            {
                return _idDiaryEntry;
            }
            set
            {
                _idDiaryEntry = value;
            }
        }
    }
}
