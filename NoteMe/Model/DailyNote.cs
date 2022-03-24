using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class DailyNote
    {
        // Fields
        private int _idDailyNote;
        private string _noteContent;
        private int _idDiaryEntry;

        // Konstruktor
        public DailyNote()
        {

        }

        // Properties
        public int IdDailyNote
        {
            get
            {
                return _idDailyNote;
            }
            set
            {
                _idDailyNote = value;
            }
        }

        public string NoteContent
        {
            get
            {
                return _noteContent;
            }
            set
            {
                _noteContent = value;
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
