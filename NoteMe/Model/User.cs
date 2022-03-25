using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NoteMe.Model
{
    class User
    {
        // Fields
        private int _idUser;
        public Binding vorname;
        public Binding nachname;
        public Binding username;

        // Konstruktor
        public User(Binding vorname, Binding nachname, Binding username)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.username = username;
        }

        // Properties
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
