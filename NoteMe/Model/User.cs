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
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Username { get; set; }

        // Konstruktor
        public User()
        {

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

        internal void Save()
        {
            DatabaseConnection.Instance.Write("insert into user (vorname,nachname,username) values ($,$,$)", Vorname, Nachname, Username);
        }
    }
}
