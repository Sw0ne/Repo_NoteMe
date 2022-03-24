using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMe.Model
{
    class DiaryEntry
    {
        // Fields
        private int _idDiaryEntry;
        private int _idUser;

        // Konstruktor
        public DiaryEntry()
        {
;
        }

        // Properties
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

        public int IdUser
        {
            get
            {
                return _idUser;
            }
            set
            {
                _idUser = value;
            }
        }

    }
}
